using AdminService.DataModel;
using AdminService.Model;
using System.Collections;

namespace AdminService.Service
{
    public interface IAdminService
    {
        Task<IEnumerable<Guid>> SaveProducts(IEnumerable<Product> products);
        Task<IEnumerable<Product>> GetProducts(IEnumerable<string> productIds);
        Task<IEnumerable<Guid>> SavePricelist(IEnumerable<PriceList> priceLists);
        Task<IEnumerable<Guid>> SavePricelistItem(Guid priceListId, IEnumerable<PriceListItem> productIds);
        Task<List<Product>> GetProductsByPriceListId(Guid priceListId);
    }
}
