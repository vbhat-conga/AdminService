using AdminService.DataModel;
using System.ComponentModel.DataAnnotations;

namespace AdminService.Model
{
    public class PriceList
    {

        public double? BasedOnAdjustmentAmount { get; set; } = null;
        public BasedOnAdjustmentTypeEnum BasedOnAdjustmentType { get; set; } = BasedOnAdjustmentTypeEnum.PercentageDiscount;
        //public PriceList1 BasedOnPriceList { get; set; }//PriceList1
        public string? ContractNumber { get; set; } = null;
        //public object CostModel { get; set; }//CostModel
        public string? Description { get; set; } = null;
        public bool DisableCurrencyAdjustment { get; set; } = false;
        public DateTime? EffectiveDate { get; set; } = null;
        public DateTime? ExpirationDate { get; set; } = null;
        public bool? IsActive { get; set; } = true;
        public TypeEnum Type { get; set; } = TypeEnum.Standard;
        public string Currency { get; set; } = "USD";

        [Required]
        public Guid PriceListId { get; set; }
        [Required]
        public string Name { get; set; }
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; } = "Admin";
        public DateTime ModifiedDate { get; set; }  = DateTime.UtcNow;
        public string? ExternalId { get; set; } = null;
    }
}
