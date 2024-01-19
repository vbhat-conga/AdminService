using AdminService.DataModel;
using System.ComponentModel.DataAnnotations;

namespace AdminService.Model
{
    public class Product
    {
        [Required]
        public ConfigurationTypeEnum ConfigurationType { get; set; }
        public string? Description { get; set; } = null;
        public DateTime? EffectiveDate { get; set; } = null;
        public string? DisplayUrl { get; set; } = null;
        public bool ExcludeFromSitemap { get; set; } = false;
        public DateTime? ExpirationDate { get; set; } = null;
        public FamilyEnum Family { get; set; } = FamilyEnum.Software;
        public bool HasAttributes { get; set; } = false;
        public bool HasDefaults { get; set; } = false;
        public bool HasOptions { get; set; } = false;
        public bool HasSearchAttributes { get; set; } = false;
        public bool IsPlainProduct { get; set; } = true;
        public string? ImageURL { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public bool IsCustomizable { get; set; } = false;
        public bool IsTabViewEnabled { get; set; } = false;
        public string ProductCode { get; set; } = "std";
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Service;
        public QuantityUOM QuantityUnitOfMeasure { get; set; } = QuantityUOM.Each;
        public double? RenewalLeadTime { get; set; } = null;
        public string? StockKeepingUnit { get; set; } = null;
        public UOMEnum Uom { get; set; } = UOMEnum.Each;
        public double Version { get; set; } = 1.0;
        [Required]
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
        public string ModifiedBy { get; set; } = "Admin";
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public string? ExternalId { get; set; } = null;
        public double Price { get; set; } = 0.0;
        public bool AutoRenew { get; set; } = false;
        public double? AutoRenewalTerm { get; set; } = null;
        public AutoRenewalType AutoRenewalType { get; set; } = AutoRenewalType.DoNotRenew;
        public BillingFrequency BillingFrequency { get; set; } = BillingFrequency.Yearly;
        public BillingRule BillingRule { get; set; } = BillingRule.BillInAdvance;
        public ChargeType ChargeType { get; set; } = ChargeType.StandardPrice;
        public int DefaultQuantity { get; set; } = 1;
        public string Currency { get; set; } = "USD";
    }
}
