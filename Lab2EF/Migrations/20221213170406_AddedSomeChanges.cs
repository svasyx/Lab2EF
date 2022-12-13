using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "shopperphoneNum",
                table: "Bill",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddCheckConstraint(
                name: "discountValue",
                table: "Shopper",
                sql: "[discountValue] <= 1");

            migrationBuilder.AddCheckConstraint(
                name: "count1",
                table: "medicineList",
                sql: "[count] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "price",
                table: "medicineList",
                sql: "[price] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "count",
                table: "Medicine",
                sql: "[count] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_shopperphoneNum",
                table: "Bill",
                column: "shopperphoneNum");

            migrationBuilder.AddCheckConstraint(
                name: "finalPrice",
                table: "Bill",
                sql: "[finalPrice] > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Shopper_shopperphoneNum",
                table: "Bill",
                column: "shopperphoneNum",
                principalTable: "Shopper",
                principalColumn: "phoneNum",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Shopper_shopperphoneNum",
                table: "Bill");

            migrationBuilder.DropCheckConstraint(
                name: "discountValue",
                table: "Shopper");

            migrationBuilder.DropCheckConstraint(
                name: "count1",
                table: "medicineList");

            migrationBuilder.DropCheckConstraint(
                name: "price",
                table: "medicineList");

            migrationBuilder.DropCheckConstraint(
                name: "count",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Bill_shopperphoneNum",
                table: "Bill");

            migrationBuilder.DropCheckConstraint(
                name: "finalPrice",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "shopperphoneNum",
                table: "Bill");
        }
    }
}
