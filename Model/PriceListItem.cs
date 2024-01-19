using AdminService.DataModel;

namespace AdminService.Model
{
    public class PriceListItem
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; } = null;
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; } = "Admin";
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public string? ExternalId { get; set; }
        public bool AutoRenew { get; set; } = false;
        public double? AutoRenewalTerm { get; set; }
        public AutoRenewalType AutoRenewalType { get; set; } = AutoRenewalType.DoNotRenew;
        public BillingFrequency BillingFrequency { get; set; } = BillingFrequency.Yearly;
        public BillingRule BillingRule { get; set; } = BillingRule.BillInAdvance;
        public ChargeType ChargeType { get; set; } = ChargeType.StandardPrice;
        public int DefaultQuantity { get; set; } = 1;
        public string? Description { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string Currency { get; set; } = "USD";
        public double Price { get; set; } = 0.0;
    }
}
