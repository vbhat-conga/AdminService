using AdminService.DataModel;

namespace AdminService.Repository
{
    public interface IAdminRepository
    {
        Task<bool> SaveProducts(List<ProductData> productDatas);
        Task<bool> SavePricelists(List<PriceListData> priceListDatas);
        Task<bool> SavePricelistItem(List<PriceListItemData> priceListItemDatas);
    }
}
