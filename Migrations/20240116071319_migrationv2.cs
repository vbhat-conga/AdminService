using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminService.Migrations
{
    /// <inheritdoc />
    public partial class migrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 755, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 755, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(7685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 753, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(6738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 753, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 754, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 754, DateTimeKind.Utc).AddTicks(9542));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 755, DateTimeKind.Utc).AddTicks(9631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 755, DateTimeKind.Utc).AddTicks(9468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 689, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 753, DateTimeKind.Utc).AddTicks(7072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 753, DateTimeKind.Utc).AddTicks(6910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 686, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 754, DateTimeKind.Utc).AddTicks(9679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PriceList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 6, 57, 11, 754, DateTimeKind.Utc).AddTicks(9542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 16, 7, 13, 19, 688, DateTimeKind.Utc).AddTicks(4798));
        }
    }
}
