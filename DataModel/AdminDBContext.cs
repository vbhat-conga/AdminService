using Microsoft.EntityFrameworkCore;

namespace AdminService.DataModel
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<ProductData> ProductDatas { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<ConfigurationType> ConfigurationTypes { get; set; }

        public DbSet<UOM> UOMs { get; set; }

        public DbSet<BasedOnAdjustmentType> BasedOnAdjustmentTypes { get; set; }

        public DbSet<Type> Types { get; set; }

        public DbSet<PriceListData> PriceLists { get; set; }

        public DbSet<PriceListItemData> PriceListItemDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PriceListItemData>()
             .ToTable("PriceListItem")
             .HasKey(c => c.PriceListItemId);

            modelBuilder.Entity<PriceListItemData>()
                .Property(x => x.PriceListItemId)
                .ValueGeneratedNever();

            modelBuilder.Entity<PriceListItemData>()
                .Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasDefaultValue(null);

            modelBuilder.Entity<PriceListItemData>()
                .Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasDefaultValue(null);

            modelBuilder.Entity<PriceListItemData>()
              .Property(x => x.CreatedBy)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue("Admin");

            modelBuilder.Entity<PriceListItemData>()
              .Property(x => x.ModifiedBy)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue("Admin");

            modelBuilder.Entity<PriceListItemData>()
              .Property(x => x.ExternalId)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue(null);

            modelBuilder.Entity<PriceListItemData>()
              .Property(x => x.CreatedDate)
              .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<PriceListItemData>()
               .Property(x => x.ModifiedDate)
               .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<PriceListItemData>()
               .Property(x => x.EffectiveDate)
               .HasDefaultValue(null);
            modelBuilder.Entity<ProductData>()
            .Property(x => x.AutoRenew)
            .HasDefaultValue(false);

            modelBuilder.Entity<PriceListItemData>()
              .Property(x => x.Currency)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue("USD");

            modelBuilder.Entity<PriceListItemData>()
            .Property(x => x.Price)
            .HasDefaultValue(0);

            modelBuilder.Entity<PriceListItemData>()
             .Property(x => x.AutoRenewalTerm)
             .HasDefaultValue(null);

            modelBuilder.Entity<PriceListItemData>()
             .Property(x => x.AutoRenewalType)
             .HasDefaultValue(AutoRenewalType.DoNotRenew)
             .HasConversion<int>();

            modelBuilder.Entity<PriceListItemData>()
             .Property(x => x.BillingFrequency)
             .HasDefaultValue(BillingFrequency.Yearly)
             .HasConversion<int>();

            modelBuilder.Entity<PriceListItemData>()
            .Property(x => x.BillingRule)
            .HasDefaultValue(BillingRule.BillInAdvance)
            .HasConversion<int>();

            modelBuilder.Entity<PriceListItemData>()
            .Property(x => x.ChargeType)
            .HasDefaultValue(ChargeType.StandardPrice)
            .HasConversion<int>();

            modelBuilder.Entity<PriceListItemData>()
               .Property(x => x.DefaultQuantity)
               .HasDefaultValue(1);



            modelBuilder.Entity<ProductData>()
             .Property(x => x.AutoRenew)
             .HasDefaultValue(false);

            modelBuilder.Entity<ProductData>()
              .Property(x => x.Currency)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue("USD");

            modelBuilder.Entity<ProductData>()
            .Property(x => x.Price)
            .HasDefaultValue(0);

            modelBuilder.Entity<ProductData>()
             .Property(x => x.AutoRenewalTerm)
             .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(x => x.AutoRenewalType)
             .HasDefaultValue(AutoRenewalType.DoNotRenew)
             .HasConversion<int>();

            modelBuilder.Entity<ProductData>()
             .Property(x => x.BillingFrequency)
             .HasDefaultValue(BillingFrequency.Yearly)
             .HasConversion<int>();

            modelBuilder.Entity<ProductData>()
            .Property(x => x.BillingRule)
            .HasDefaultValue(BillingRule.BillInAdvance)
            .HasConversion<int>();

            modelBuilder.Entity<ProductData>()
            .Property(x => x.ChargeType)
            .HasDefaultValue(ChargeType.StandardPrice)
            .HasConversion<int>();

            modelBuilder.Entity<ProductData>()
               .Property(x => x.DefaultQuantity)
               .HasDefaultValue(1);

            modelBuilder.Entity<PriceListItemData>()
             .Property(x => x.ExpirationDate)
             .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<PriceListItemData>()
            .Property(x => x.IsActive)
            .HasDefaultValue(true);

            modelBuilder.Entity<BasedOnAdjustmentType>()
             .ToTable("BasedOnAdjustmentType")
             .HasKey(c => c.Id);

            modelBuilder.Entity<BasedOnAdjustmentType>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<BasedOnAdjustmentType>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            modelBuilder.Entity<Type>()
             .ToTable("Type")
             .HasKey(c => c.Id);

            modelBuilder.Entity<Type>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Type>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            modelBuilder.Entity<Family>()
              .ToTable("Family")
              .HasKey(c => c.Id);

            modelBuilder.Entity<Family>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Family>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            modelBuilder.Entity<ProductType>()
               .ToTable("ProductType")
               .HasKey(c => c.Id);

            modelBuilder.Entity<ProductType>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<ProductType>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            modelBuilder.Entity<ConfigurationType>()
               .ToTable("ConfigurationType")
               .HasKey(c => c.Id);

            modelBuilder.Entity<ConfigurationType>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<ConfigurationType>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            modelBuilder.Entity<UOM>()
               .ToTable("UOM")
               .HasKey(c => c.Id);

            modelBuilder.Entity<UOM>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<UOM>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            modelBuilder.Entity<PriceListData>()
               .ToTable("PriceList")
               .HasKey(c => c.PriceListId);

            modelBuilder.Entity<PriceListData>()
                .Property(x => x.PriceListId)
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedNever();

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .HasDefaultValue(null);

            modelBuilder.Entity<PriceListData>()
               .HasIndex(c => c.PriceListId)
               .IsUnique()
               .HasDatabaseName("idx_PriceListId");

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.BasedOnAdjustmentAmount)
               .HasColumnType("float")
               .HasDefaultValue(null);

            modelBuilder.Entity<PriceListData>()
              .Property(x => x.BasedOnAdjustmentType)
              .HasConversion<int>()
              .HasDefaultValue(BasedOnAdjustmentTypeEnum.PercentageDiscount);

            modelBuilder.Entity<PriceListData>()
             .Property(x => x.Type)
             .HasConversion<int>()
             .HasDefaultValue(TypeEnum.Standard);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.IsActive)
               .HasDefaultValue(true);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.DisableCurrencyAdjustment)
               .HasDefaultValue(false);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.CreatedDate)
               .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.ModifiedDate)
               .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.EffectiveDate)
               .HasDefaultValue(DateTime.MinValue);

            modelBuilder.Entity<PriceListData>()
              .Property(x => x.ExpirationDate)
              .HasDefaultValue(DateTime.MinValue);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.ContractNumber)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .HasDefaultValue(null);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .HasDefaultValue(null);

            modelBuilder.Entity<PriceListData>()
               .Property(x => x.CreatedBy)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .HasDefaultValue("Admin");

            modelBuilder.Entity<PriceListData>()
              .Property(x => x.ModifiedBy)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue("Admin");

            modelBuilder.Entity<PriceListData>()
              .Property(x => x.ExternalId)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue(null);

            modelBuilder.Entity<PriceListData>()
              .Property(x => x.Currency)
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .HasDefaultValue("USD");

            modelBuilder.Entity<ProductData>()
              .ToTable("Product")
              .HasKey(c => c.ProductId);

            modelBuilder.Entity<ProductData>()
                .Property(c => c.ProductId)
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedNever();

            modelBuilder.Entity<ProductData>()
                .Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
                .Property(c => c.ProductCode)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasDefaultValue("std");

            modelBuilder.Entity<ProductData>()
               .Property(c => c.Description)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.DisplayUrl)
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.ImageURL)
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.StockKeepingUnit)
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.CreatedBy)
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .HasDefaultValue("admin");

            modelBuilder.Entity<ProductData>()
             .Property(c => c.ModifiedBy)
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .HasDefaultValue("admin");

            modelBuilder.Entity<ProductData>()
             .Property(c => c.ExternalId)
             .HasColumnType("varchar")
             .HasMaxLength(50)
             .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.RenewalLeadTime)
             .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.Version)
             .HasDefaultValue(1.0);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.Uom)
             .HasConversion<int>()
             .HasDefaultValue(UOMEnum.Each);

            modelBuilder.Entity<ProductData>()
             .Property(c => c.QuantityUnitOfMeasure)
             .HasConversion<int>()
             .HasDefaultValue(QuantityUOM.Each);

            modelBuilder.Entity<ProductData>()
            .Property(c => c.Family)
            .HasConversion<int>()
            .HasDefaultValue(FamilyEnum.Software);

            modelBuilder.Entity<ProductData>()
            .Property(c => c.ProductType)
            .HasConversion<int>()
            .HasDefaultValue(ProductTypeEnum.License);

            modelBuilder.Entity<ProductData>()
            .Property(c => c.ConfigurationType)
            .HasConversion<int>()
            .HasDefaultValue(ConfigurationTypeEnum.Standalone);

            modelBuilder.Entity<ProductData>()
              .HasIndex(c => c.ConfigurationType)
              .HasDatabaseName("idx_ConfigurationType");

            modelBuilder.Entity<ProductData>()
            .Property(c => c.CreatedDate)
            .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<ProductData>()
            .Property(c => c.ModifiedDate)
            .HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<ProductData>()
               .Property(c => c.EffectiveDate)
               .HasDefaultValue(null);

            modelBuilder.Entity<ProductData>()
               .Property(c => c.IsActive)
               .HasDefaultValue(true);

            modelBuilder.Entity<ProductData>()
              .Property(c => c.HasAttributes)
              .HasDefaultValue(false);

            modelBuilder.Entity<ProductData>()
               .HasIndex(c => c.ProductId)
               .IsUnique()
               .HasDatabaseName("idx_ProductId");


            modelBuilder.Entity<ProductData>()
              .Property(c => c.HasOptions)
              .HasDefaultValue(false);


            modelBuilder.Entity<ProductData>()
              .Property(c => c.HasDefaults)
              .HasDefaultValue(false);

            modelBuilder.Entity<ProductData>()
              .Property(c => c.HasSearchAttributes)
              .HasDefaultValue(false);


            modelBuilder.Entity<ProductData>()
              .Property(c => c.IsPlainProduct)
              .HasDefaultValue(true);


            modelBuilder.Entity<ProductData>()
              .Property(c => c.IsCustomizable)
              .HasDefaultValue(false);

            modelBuilder.Entity<ProductData>()
              .Property(c => c.IsTabViewEnabled)
              .HasDefaultValue(false);

            modelBuilder.Entity<ProductData>()
              .Property(c => c.ExcludeFromSitemap)
              .HasDefaultValue(false);
            modelBuilder.Entity<Type>()
               .HasData(
               new Type
               {
                   Id = 1,
                   Description = "Standard"
               },
              new Type
              {
                  Id = 2,
                  Description = "Contract"
              });

            modelBuilder.Entity<BasedOnAdjustmentType>()
              .HasData(
              new BasedOnAdjustmentType
              {
                  Id = 1,
                  Description = "PercentageDiscount"
              },
             new BasedOnAdjustmentType
             {
                 Id = 2,
                 Description = "AbsoluteDiscount"
             },
             new BasedOnAdjustmentType
             {
                 Id = 3,
                 Description = "MarkupAmount"
             },
             new BasedOnAdjustmentType
             {
                 Id = 4,
                 Description = "PriceFactor"
             },
             new BasedOnAdjustmentType
             {
                 Id = 5,
                 Description = "Markup"
             });

            modelBuilder.Entity<ProductType>()
              .HasData(
              new ProductType
              {
                  Id = 1,
                  Description = "Equipment"
              },
             new ProductType
             {
                 Id = 2,
                 Description = "Service"
             },
             new ProductType
             {
                 Id = 3,
                 Description = "Entitlement"
             },
             new ProductType
             {
                 Id = 4,
                 Description = "License"
             },
             new ProductType
             {
                 Id = 5,
                 Description = "Maintenance"
             },
             new ProductType
             {
                 Id = 6,
                 Description = "Wallet"
             },
             new ProductType
             {
                 Id = 7,
                 Description = "Subscription"
             },
             new ProductType
             {
                 Id = 8,
                 Description = "ProfessionalServices"
             },
             new ProductType
             {
                 Id = 9,
                 Description = "Solution"
             });


            modelBuilder.Entity<Family>()
              .HasData(
              new Family
              {
                  Id = 1,
                  Description = "Software"
              },
             new Family
             {
                 Id = 2,
                 Description = "Hardware"
             },
             new Family
             {
                 Id = 3,
                 Description = "MaintenanceHW"
             },
             new Family
             {
                 Id = 4,
                 Description = "Implementation"
             },
             new Family
             {
                 Id = 5,
                 Description = "Training"
             },
             new Family
             {
                 Id = 6,
                 Description = "Other"
             },
             new Family
             {
                 Id = 7,
                 Description = "MaintenanceSW"
             });

            modelBuilder.Entity<UOM>()
              .HasData(
              new UOM
              {
                  Id = 1,
                  Description = "Each"
              },
             new UOM
             {
                 Id = 2,
                 Description = "Hour"
             },
             new UOM
             {
                 Id = 3,
                 Description = "Day"
             },
             new UOM
             {
                 Id = 4,
                 Description = "Month"
             },
             new UOM
             {
                 Id = 5,
                 Description = "Year"
             },
             new UOM
             {
                 Id = 6,
                 Description = "Quarter"
             },
             new UOM
             {
                 Id = 7,
                 Description = "Case"
             },
             new UOM
             {
                 Id = 8,
                 Description = "Gallon"
             });
            modelBuilder.Entity<ConfigurationType>()
             .HasData(
             new ConfigurationType
             {
                 Id = 1,
                 Description = "Standalone"
             },
            new ConfigurationType
            {
                Id = 2,
                Description = "Bundle"
            },
            new ConfigurationType
            {
                Id = 3,
                Description = "Option"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
