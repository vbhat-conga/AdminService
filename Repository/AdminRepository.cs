using AdminService.DataModel;

namespace AdminService.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminDbContext _adminDbContext;
        public AdminRepository(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }

        public async Task<bool> SavePricelistItem(List<PriceListItemData> priceListItemDatas)
        {
            await _adminDbContext.PriceListItemDatas.AddRangeAsync(priceListItemDatas);
            await _adminDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SavePricelists(List<PriceListData> priceListDatas)
        {
            await _adminDbContext.PriceLists.AddRangeAsync(priceListDatas);
            await _adminDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveProducts(List<ProductData> productDatas)
        {
            await _adminDbContext.ProductDatas.AddRangeAsync(productDatas);
            await _adminDbContext.SaveChangesAsync();
            return true;

        }
    }
}
