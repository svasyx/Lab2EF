using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedLinks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Bill_BillID",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_BillID",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_medicineList_billID",
                table: "medicineList");

            migrationBuilder.DropColumn(
                name: "BillID",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "bill_Id",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "medicineLID",
                table: "Medicine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "recipeID",
                table: "Bill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicineList_billID",
                table: "medicineList",
                column: "billID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_medicineLID",
                table: "Medicine",
                column: "medicineLID");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_recipeID",
                table: "Bill",
                column: "recipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Recipe_recipeID",
                table: "Bill",
                column: "recipeID",
                principalTable: "Recipe",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_medicineList_medicineLID",
                table: "Medicine",
                column: "medicineLID",
                principalTable: "medicineList",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Recipe_recipeID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_medicineList_medicineLID",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_medicineList_billID",
                table: "medicineList");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_medicineLID",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Bill_recipeID",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "bill_Id",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "medicineLID",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "recipeID",
                table: "Bill");

            migrationBuilder.AddColumn<int>(
                name: "BillID",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_BillID",
                table: "Recipe",
                column: "BillID",
                unique: true,
                filter: "[BillID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_medicineList_billID",
                table: "medicineList",
                column: "billID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Bill_BillID",
                table: "Recipe",
                column: "BillID",
                principalTable: "Bill",
                principalColumn: "ID");
        }
    }
}
