using AdminService.DataModel;
using AdminService.Model;
using AdminService.Repository;
using CartServicePOC.Extensions;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;

namespace AdminService.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IDatabase _database;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly ActivitySource _activitySource = new(Instrumentation.ActivitySourceName);
        public AdminService(IAdminRepository adminRepository, IConnectionMultiplexer connectionMultiplexer)
        {
            //var redis = ConnectionMultiplexer.Connect("localhost:6379");
            //_database = redis.GetDatabase();
            _adminRepository = adminRepository;
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>

        public async Task<IEnumerable<Guid>> SaveProducts(IEnumerable<Product> products)
        {
            //TODO: Not all of the property is present here what we have in CPQ but most of it is present.
            var productDatas = new List<ProductData>();
            foreach (var product in products)
            {
                productDatas.Add(new ProductData
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    ConfigurationType = product.ConfigurationType,
                    HasAttributes = product.HasAttributes,
                    HasDefaults = product.HasDefaults,
                    HasOptions = product.HasOptions,
                    HasSearchAttributes = product.HasSearchAttributes,
                    IsPlainProduct = product.IsPlainProduct,
                    Price= product.Price,
                    AutoRenew = product.AutoRenew,
                    BillingFrequency = product.BillingFrequency,
                    BillingRule = product.BillingRule,
                    ChargeType = product.ChargeType,
                    AutoRenewalTerm = product.AutoRenewalTerm,
                    AutoRenewalType = product.AutoRenewalType,
                });
            }
            if (await _adminRepository.SaveProducts(productDatas))
            {
                //TODO: This is not final implemenation and lot of things need to be thought
                //even before making this choice. But for now i am going with this.
                var stringBatch = _database.CreateBatch();
                var hashBatch = _database.CreateBatch();
                var batchtask = new List<Task>();
                var batchStringtask = new List<Task<bool>>();
                productDatas.ForEach(x =>
                {
                    //TODO: where should we save in cache redis string or hash?
                    //if its just cache may be we can save in string or if we are using redis 
                    //as data store, then we can think of hash.
                    // And entire object is needed in cache or only few property which is getting queried?
                    var result = JsonSerializer.Serialize(x);
                    batchStringtask.Add(stringBatch.StringSetAsync($"s-cpq-{x.ProductId}", result));
                    HashEntry[] productHashEntry =
                    {
                        new HashEntry(nameof(x.ProductId), x.ProductId.ToString()),
                        new HashEntry(nameof(x.ConfigurationType), (int)x.ConfigurationType),
                        new HashEntry(nameof(x.HasAttributes), x.HasAttributes),
                        new HashEntry(nameof(x.HasDefaults), x.HasDefaults),
                        new HashEntry(nameof(x.HasOptions), x.HasOptions),
                        new HashEntry(nameof(x.HasSearchAttributes), x.HasSearchAttributes),
                        new HashEntry(nameof(x.IsActive), x.IsActive),
                        new HashEntry(nameof(x.IsPlainProduct), x.IsPlainProduct),
                        new HashEntry(nameof(x.Price), x.Price),
                        new HashEntry(nameof(x.AutoRenew), x.AutoRenew),
                        new HashEntry(nameof(x.BillingFrequency), x.BillingFrequency.ToString()),
                        new HashEntry(nameof(x.BillingRule), x.BillingRule.ToString()),
                        new HashEntry(nameof(x.ChargeType), x.ChargeType.ToString()),
                        new HashEntry(nameof(x.AutoRenewalType), x.AutoRenewalType.ToString())
                    };
                    batchtask.Add(hashBatch.HashSetAsync($"h-cpq-{x.ProductId}", productHashEntry));
                });

                hashBatch.Execute();
                stringBatch.Execute();
                await Task.WhenAll(batchtask);
                await Task.WhenAll(batchStringtask);
                return products.Select(x => x.ProductId);
            }

            return Enumerable.Empty<Guid>();
        }

        public async Task<IEnumerable<Guid>> SavePricelist(IEnumerable<PriceList> priceLists)
        {
            //TODO: Not all of the property is present here what we have in CPQ but most of it is present.
            var priceListDatas = new List<PriceListData>();
            foreach (var priceList in priceLists)
            {
                priceListDatas.Add(new PriceListData
                {
                    PriceListId = priceList.PriceListId,
                    Name = priceList.Name,
                    Description = priceList.Description,
                    BasedOnAdjustmentAmount = priceList.BasedOnAdjustmentAmount,
                    IsActive = priceList.IsActive,
                    BasedOnAdjustmentType = priceList.BasedOnAdjustmentType,
                    EffectiveDate   = priceList.EffectiveDate,
                    ExpirationDate = priceList.ExpirationDate
                });
            }
            if (await _adminRepository.SavePricelists(priceListDatas))
            {
                var stringBatch = _database.CreateBatch();
                var hashBatch = _database.CreateBatch();
                var batchtask = new List<Task>();
                var batchStringtask = new List<Task<bool>>();
                priceListDatas.ForEach(x =>
                {
                    //TODO: where should we save in cache redis string or hash?
                    var result = JsonSerializer.Serialize(x);
                    batchStringtask.Add(stringBatch.StringSetAsync($"s-cpq-{x.PriceListId}", result));
                    HashEntry[] productHashEntry =
                    {
                        new HashEntry(nameof(x.Name), x.Name),
                        new HashEntry(nameof(x.PriceListId), x.PriceListId.ToString()),
                    };
                    batchtask.Add(hashBatch.HashSetAsync($"h-cpq-{x.PriceListId}", productHashEntry));
                });
                hashBatch.Execute();
                stringBatch.Execute();
                await Task.WhenAll(batchtask);
                await Task.WhenAll(batchStringtask);
                return priceLists.Select(x => x.PriceListId);
            }
            return Enumerable.Empty<Guid>();
        }

        public async Task<PriceList?> GetPriceList(Guid Id)
        {
            //TODO This needs a change, whether to get from redis string or redis hash
            // what happens when data is not peresnt in cache?
            var priceListString = await _database.StringGetAsync($"s-cpq-{Id}");
            if (priceListString.IsNullOrEmpty)
                return null;

            var priceList = JsonSerializer.Deserialize<PriceList>(priceListString!);
            return priceList;
        }
        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string> productIds)
        {
            //TODO: what happens when data is not present in cache?
            using var activity = _activitySource.StartActivity($"{nameof(AdminService)} : GetProducts", ActivityKind.Server);
            var batch = _database.CreateBatch();
            var batchtask = new List<Task<HashEntry[]>>();
            foreach (var productId in productIds)
            {
                batchtask.Add(batch.HashGetAllAsync($"h-cpq-{productId}"));
            }
            batch.Execute();
            var hashEntries = await Task.WhenAll(batchtask);
            if (hashEntries.Any())
            {
                var products = hashEntries.Select(RedisExtension.ConvertFromRedis<Product>);
                return products;
            }
            return Enumerable.Empty<Product>();
        }

        public async Task<IEnumerable<Guid>> SavePricelistItem(Guid priceListId, IEnumerable<PriceListItem> priceListItems)
        {
            //TODO: Not all of the property is present here what we have in CPQ.
            //May be 50% since lot of them are nullable.
            var priceListItemDatas = new List<PriceListItemData>();
            foreach (var item in priceListItems)
            {
                priceListItemDatas.Add(new PriceListItemData
                {
                    PriceListItemId = Guid.NewGuid(),
                    ProductId = item.ProductId,
                    PriceListId = priceListId,
                    Price = item.Price,
                    AutoRenew = item.AutoRenew,
                    BillingFrequency = item.BillingFrequency,
                    BillingRule = item.BillingRule,
                    ChargeType = item.ChargeType,
                    AutoRenewalTerm = item.AutoRenewalTerm,
                    AutoRenewalType = item.AutoRenewalType,
                    Currency = item.Currency,
                });
            }
            if (await _adminRepository.SavePricelistItem(priceListItemDatas))
            {
                //TODO: Need to re think on what redis data structure to use. Cache stratergy?
                var setBatch = _database.CreateBatch();
                var batchtask = new List<Task>();
                var setBatch2 = _database.CreateBatch();
                var batchtask3 = new List<Task<bool>>();
                var hashBatch = _database.CreateBatch();
                var batchtask2 = new List<Task<bool>>();
                priceListItemDatas.ForEach(x =>
                {
                    var hashEntry = RedisExtension.ToHashEntries(x);
                    batchtask.Add(hashBatch.HashSetAsync($"h-cpq-{x.PriceListItemId}", hashEntry));
                    batchtask2.Add(setBatch.SetAddAsync($"se-cpq-{x.ProductId}", x.PriceListItemId.ToString()));
                    batchtask3.Add(setBatch.SetAddAsync($"se-cpq-{priceListId}", x.PriceListItemId.ToString()));
                });
                hashBatch.Execute();
                setBatch.Execute();
                setBatch2.Execute();
                await Task.WhenAll(batchtask);
                await Task.WhenAll(batchtask2);
                await Task.WhenAll(batchtask3);
            }
            return priceListItemDatas.Select(x => x.PriceListItemId);
        }

        public async Task<IEnumerable<PriceListItemData>> GetPriceListItemByPriceListId(Guid priceListId, PriceListItemQueryRequest priceListItemQueryRequest)
        {
            //TODO: when no data in cache?
            var productList = new List<Product>();
            var batch = _database.CreateBatch();
            var hashTask=new List<Task<HashEntry[]>>();
            var batch1 = _database.CreateBatch();
            var setTask = new List<Task<RedisValue[]>>();
            priceListItemQueryRequest.Ids.ToList().ForEach(id =>
            {
                setTask.Add(batch1.SetMembersAsync($"se-cpq-{id}"));
               
            });
            batch1.Execute();
            while (setTask.Any())
            {
                var completedTask = await Task.WhenAny(setTask);
                setTask.Remove(completedTask);
                var priceItems = await completedTask;
                foreach (var entry in priceItems)
                {
                    hashTask.Add(batch.HashGetAllAsync($"h-cpq-{entry}"));
                }
            }
            batch.Execute();
            var hashEntry = await Task.WhenAll(hashTask);
            var result = hashEntry.Select(RedisExtension.ConvertFromRedis<PriceListItemData>);
            if (result != null && result.Any())
                return result.Where(x=>x.PriceListId == priceListId);

            return Enumerable.Empty<PriceListItemData>();
        }
    }
}
