﻿// <auto-generated />
using System;
using AdminService.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminService.Migrations
{
    [DbContext(typeof(AdminDbContext))]
    partial class AdminDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminService.DataModel.BasedOnAdjustmentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("BasedOnAdjustmentType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "PercentageDiscount"
                        },
                        new
                        {
                            Id = 2,
                            Description = "AbsoluteDiscount"
                        },
                        new
                        {
                            Id = 3,
                            Description = "MarkupAmount"
                        },
                        new
                        {
                            Id = 4,
                            Description = "PriceFactor"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Markup"
                        });
                });

            modelBuilder.Entity("AdminService.DataModel.ConfigurationType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("ConfigurationType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Standalone"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bundle"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Option"
                        });
                });

            modelBuilder.Entity("AdminService.DataModel.Family", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Family", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Software"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Hardware"
                        },
                        new
                        {
                            Id = 3,
                            Description = "MaintenanceHW"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Implementation"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Training"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Other"
                        },
                        new
                        {
                            Id = 7,
                            Description = "MaintenanceSW"
                        });
                });

            modelBuilder.Entity("AdminService.DataModel.PriceListData", b =>
                {
                    b.Property<Guid>("PriceListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("BasedOnAdjustmentAmount")
                        .HasColumnType("float");

                    b.Property<int>("BasedOnAdjustmentType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("ContractNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Admin");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 954, DateTimeKind.Utc).AddTicks(8221));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("USD");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<bool>("DisableCurrencyAdjustment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("EffectiveDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<DateTime?>("ExpirationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Admin");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 954, DateTimeKind.Utc).AddTicks(8566));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("PriceListId");

                    b.HasIndex("PriceListId")
                        .IsUnique()
                        .HasDatabaseName("idx_PriceListId");

                    b.ToTable("PriceList", (string)null);
                });

            modelBuilder.Entity("AdminService.DataModel.PriceListItemData", b =>
                {
                    b.Property<Guid>("PriceListItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AutoRenew")
                        .HasColumnType("bit");

                    b.Property<double?>("AutoRenewalTerm")
                        .HasColumnType("float");

                    b.Property<int>("AutoRenewalType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<int>("BillingFrequency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(6);

                    b.Property<int>("BillingRule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ChargeType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Admin");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 951, DateTimeKind.Utc).AddTicks(2491));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("USD");

                    b.Property<int>("DefaultQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 952, DateTimeKind.Utc).AddTicks(1499));

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Admin");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 951, DateTimeKind.Utc).AddTicks(2910));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<double>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<Guid>("PriceListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PriceListItemId");

                    b.ToTable("PriceListItem", (string)null);
                });

            modelBuilder.Entity("AdminService.DataModel.ProductData", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AutoRenew")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<double?>("AutoRenewalTerm")
                        .HasColumnType("float");

                    b.Property<int>("AutoRenewalType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<int>("BillingFrequency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(6);

                    b.Property<int>("BillingRule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ChargeType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ConfigurationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("admin");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 957, DateTimeKind.Utc).AddTicks(4672));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("USD");

                    b.Property<int>("DefaultQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("DisplayUrl")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ExcludeFromSitemap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("Family")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<bool>("HasAttributes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("HasDefaults")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("HasOptions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("HasSearchAttributes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ImageURL")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsCustomizable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPlainProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsTabViewEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("admin");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 1, 18, 11, 33, 44, 957, DateTimeKind.Utc).AddTicks(5091));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<double>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("std");

                    b.Property<int>("ProductType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(4);

                    b.Property<int>("QuantityUnitOfMeasure")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<double?>("RenewalLeadTime")
                        .HasColumnType("float");

                    b.Property<string>("StockKeepingUnit")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("Uom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<double>("Version")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.HasKey("ProductId");

                    b.HasIndex("ConfigurationType")
                        .HasDatabaseName("idx_ConfigurationType");

                    b.HasIndex("ProductId")
                        .IsUnique()
                        .HasDatabaseName("idx_ProductId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("AdminService.DataModel.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("ProductType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Equipment"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Service"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Entitlement"
                        },
                        new
                        {
                            Id = 4,
                            Description = "License"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Maintenance"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Wallet"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Subscription"
                        },
                        new
                        {
                            Id = 8,
                            Description = "ProfessionalServices"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Solution"
                        });
                });

            modelBuilder.Entity("AdminService.DataModel.Type", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Standard"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Contract"
                        });
                });

            modelBuilder.Entity("AdminService.DataModel.UOM", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("UOM", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Each"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Hour"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Day"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Month"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Year"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Quarter"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Case"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Gallon"
                        });
                });

            modelBuilder.Entity("PriceListDataProductData", b =>
                {
                    b.Property<Guid>("PriceListDatasPriceListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductDatasProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PriceListDatasPriceListId", "ProductDatasProductId");

                    b.HasIndex("ProductDatasProductId");

                    b.ToTable("PriceListDataProductData");
                });

            modelBuilder.Entity("PriceListDataProductData", b =>
                {
                    b.HasOne("AdminService.DataModel.PriceListData", null)
                        .WithMany()
                        .HasForeignKey("PriceListDatasPriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminService.DataModel.ProductData", null)
                        .WithMany()
                        .HasForeignKey("ProductDatasProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
