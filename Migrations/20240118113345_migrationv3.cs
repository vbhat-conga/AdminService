using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminService.Migrations
{
    /// <inheritdoc />
    public partial class migrationv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 957, DateTimeKind.Utc).AddTicks(5091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 957, DateTimeKind.Utc).AddTicks(4672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PriceListItem",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 951, DateTimeKind.Utc).AddTicks(2910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 951, DateTimeKind.Utc).AddTicks(2491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.AddColumn<bool>(
                name: "AutoRenew",
                table: "PriceListItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "AutoRenewalTerm",
                table: "PriceListItem",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutoRenewalType",
                table: "PriceListItem",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "BillingFrequency",
                table: "PriceListItem",
                type: "int",
                nullable: false,
                defaultValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "BillingRule",
                table: "PriceListItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChargeType",
                table: "PriceListItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "PriceListItem",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "USD");

            migrationBuilder.AddColumn<int>(
                name: "DefaultQuantity",
                table: "PriceListItem",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PriceListItem",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 952, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "PriceListItem",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PriceListItem",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PriceListItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 954, DateTimeKind.Utc).AddTicks(8566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 954, DateTimeKind.Utc).AddTicks(8221),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4798));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoRenew",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "AutoRenewalTerm",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "AutoRenewalType",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "BillingFrequency",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "BillingRule",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "ChargeType",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "DefaultQuantity",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PriceListItem");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PriceListItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 957, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 957, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PriceListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(7685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 951, DateTimeKind.Utc).AddTicks(2910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(6738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 951, DateTimeKind.Utc).AddTicks(2491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 954, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 18, 11, 33, 44, 954, DateTimeKind.Utc).AddTicks(8221));
        }
    }
}
