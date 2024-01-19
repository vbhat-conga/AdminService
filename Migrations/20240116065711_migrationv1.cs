using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminService.Migrations
{
    /// <inheritdoc />
    public partial class migrationv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasedOnAdjustmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasedOnAdjustmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasedOnAdjustmentAmount = table.Column<double>(type: "float", nullable: true),
                    BasedOnAdjustmentType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ContractNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DisableCurrencyAdjustment = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Currency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "USD"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Admin"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 754, DateTimeKind.Utc).AddTicks(9542)),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Admin"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 754, DateTimeKind.Utc).AddTicks(9679)),
                    ExternalId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.PriceListId);
                });

            migrationBuilder.CreateTable(
                name: "PriceListItem",
                columns: table => new
                {
                    PriceListItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Admin"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 753, DateTimeKind.Utc).AddTicks(6910)),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Admin"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 753, DateTimeKind.Utc).AddTicks(7072))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListItem", x => x.PriceListItemId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigurationType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisplayUrl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ExcludeFromSitemap = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Family = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HasAttributes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasDefaults = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasOptions = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasSearchAttributes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPlainProduct = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ImageURL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsCustomizable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTabViewEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProductCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "std"),
                    ProductType = table.Column<int>(type: "int", nullable: false, defaultValue: 4),
                    QuantityUnitOfMeasure = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    RenewalLeadTime = table.Column<double>(type: "float", nullable: true),
                    StockKeepingUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Uom = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Version = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "admin"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 755, DateTimeKind.Utc).AddTicks(9468)),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "admin"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 755, DateTimeKind.Utc).AddTicks(9631)),
                    ExternalId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    AutoRenew = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AutoRenewalTerm = table.Column<double>(type: "float", nullable: true),
                    AutoRenewalType = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    BillingFrequency = table.Column<int>(type: "int", nullable: false, defaultValue: 6),
                    BillingRule = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ChargeType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Currency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "USD")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UOM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceListDataProductData",
                columns: table => new
                {
                    PriceListDatasPriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDatasProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDataProductData", x => new { x.PriceListDatasPriceListId, x.ProductDatasProductId });
                    table.ForeignKey(
                        name: "FK_PriceListDataProductData_PriceList_PriceListDatasPriceListId",
                        column: x => x.PriceListDatasPriceListId,
                        principalTable: "PriceList",
                        principalColumn: "PriceListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListDataProductData_Product_ProductDatasProductId",
                        column: x => x.ProductDatasProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BasedOnAdjustmentType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "PercentageDiscount" },
                    { 2, "AbsoluteDiscount" },
                    { 3, "MarkupAmount" },
                    { 4, "PriceFactor" },
                    { 5, "Markup" }
                });

            migrationBuilder.InsertData(
                table: "ConfigurationType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Standalone" },
                    { 2, "Bundle" },
                    { 3, "Option" }
                });

            migrationBuilder.InsertData(
                table: "Family",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Software" },
                    { 2, "Hardware" },
                    { 3, "MaintenanceHW" },
                    { 4, "Implementation" },
                    { 5, "Training" },
                    { 6, "Other" },
                    { 7, "MaintenanceSW" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Equipment" },
                    { 2, "Service" },
                    { 3, "Entitlement" },
                    { 4, "License" },
                    { 5, "Maintenance" },
                    { 6, "Wallet" },
                    { 7, "Subscription" },
                    { 8, "ProfessionalServices" },
                    { 9, "Solution" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Standard" },
                    { 2, "Contract" }
                });

            migrationBuilder.InsertData(
                table: "UOM",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Each" },
                    { 2, "Hour" },
                    { 3, "Day" },
                    { 4, "Month" },
                    { 5, "Year" },
                    { 6, "Quarter" },
                    { 7, "Case" },
                    { 8, "Gallon" }
                });

            migrationBuilder.CreateIndex(
                name: "idx_PriceListId",
                table: "PriceList",
                column: "PriceListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDataProductData_ProductDatasProductId",
                table: "PriceListDataProductData",
                column: "ProductDatasProductId");

            migrationBuilder.CreateIndex(
                name: "idx_ConfigurationType",
                table: "Product",
                column: "ConfigurationType");

            migrationBuilder.CreateIndex(
                name: "idx_ProductId",
                table: "Product",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasedOnAdjustmentType");

            migrationBuilder.DropTable(
                name: "ConfigurationType");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "PriceListDataProductData");

            migrationBuilder.DropTable(
                name: "PriceListItem");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "UOM");

            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
