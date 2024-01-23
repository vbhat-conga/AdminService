using AdminService.DataModel;
using AdminService.Model;
using AdminService.Repository;
using CartServicePOC.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace AdminService.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IDatabase _database;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _database = redis.GetDatabase();
        }


        public async Task<IEnumerable<Guid>> SaveProducts(IEnumerable<Product> products)
        {
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
                var stringBatch = _database.CreateBatch();
                var hashBatch = _database.CreateBatch();
                var batchtask = new List<Task>();
                var batchStringtask = new List<Task<bool>>();
                productDatas.ForEach(x =>
                {
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

        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string> productIds)
        {
            var batch = _database.CreateBatch();
            var batchtask = new List<Task<HashEntry[]>>();
            foreach (var productId in productIds)
            {
                batchtask.Add(batch.HashGetAllAsync($"h-cpq-{productId}"));
            }
            batch.Execute();
            var hashEntries = await Task.WhenAll(batchtask);
            //var products=new List<Product>();
            if (hashEntries.Any())
            {
                var products = hashEntries.Select(RedisExtension.ConvertFromRedis<Product>);
                return products;
            }
            //foreach (var entry in hashEntries)
            //{
            //    if (!entry.IsNull)
            //    {
            //        products.Add(JsonSerializer.Deserialize<Product>(entry));
            //    }

            //}
            return Enumerable.Empty<Product>();
        }

        public async Task<IEnumerable<Guid>> SavePricelistItem(Guid priceListId, IEnumerable<PriceListItem> priceListItems)
        {
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
            var productList = new List<Product>();
            var batch = _database.CreateBatch();
            var hashTask=new List<Task<HashEntry[]>>();
            priceListItemQueryRequest.Ids.ToList().ForEach(id =>
            {
                hashTask.Add(batch.HashGetAllAsync($"h-cpq-{id}"));
            });
            batch.Execute();
            var hashEntry = await Task.WhenAll(hashTask);
            var result = hashEntry.Select(RedisExtension.ConvertFromRedis<PriceListItemData>);
            if (result != null && result.Any())
                return result.Where(x=>x.PriceListId == priceListId);

            //var items = await _database.StringGetAsync($"s-cpq-{priceListId}-items");
            //var products = JsonSerializer.Deserialize<List<PriceListItemData>>(items!);
            //foreach (var item in products!)
            //{
            //    var product = await _database.StringGetAsync($"s-cpq-{item.ProductId}");
            //    var productData = JsonSerializer.Deserialize<Product>(product!);
            //    productList.Add(productData!);
            //}

            //return productList;
            return Enumerable.Empty<PriceListItemData>();
        }
    }
}
