using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedLinksVer5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Recipe_recipeID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_medicineList_listIDID",
                table: "Medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_medicineList_Medicine_Article",
                table: "medicineList");

            migrationBuilder.DropIndex(
                name: "IX_medicineList_Article",
                table: "medicineList");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_listIDID",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Bill_recipeID",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "bill_Id",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Article",
                table: "medicineList");

            migrationBuilder.DropColumn(
                name: "listIDID",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "recipeID",
                table: "Bill");

            migrationBuilder.AddColumn<int>(
                name: "billID",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicinemedicineList",
                columns: table => new
                {
                    listifmedlistsArticle = table.Column<float>(type: "real", nullable: false),
                    medicineListsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinemedicineList", x => new { x.listifmedlistsArticle, x.medicineListsID });
                    table.ForeignKey(
                        name: "FK_MedicinemedicineList_Medicine_listifmedlistsArticle",
                        column: x => x.listifmedlistsArticle,
                        principalTable: "Medicine",
                        principalColumn: "Article",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinemedicineList_medicineList_medicineListsID",
                        column: x => x.medicineListsID,
                        principalTable: "medicineList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_billID",
                table: "Recipe",
                column: "billID",
                unique: true,
                filter: "[billID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinemedicineList_medicineListsID",
                table: "MedicinemedicineList",
                column: "medicineListsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Bill_billID",
                table: "Recipe",
                column: "billID",
                principalTable: "Bill",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Bill_billID",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "MedicinemedicineList");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_billID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "billID",
                table: "Recipe");

            migrationBuilder.AddColumn<int>(
                name: "bill_Id",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Article",
                table: "medicineList",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "listIDID",
                table: "Medicine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "recipeID",
                table: "Bill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicineList_Article",
                table: "medicineList",
                column: "Article");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_listIDID",
                table: "Medicine",
                column: "listIDID");

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
                name: "FK_Medicine_medicineList_listIDID",
                table: "Medicine",
                column: "listIDID",
                principalTable: "medicineList",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_medicineList_Medicine_Article",
                table: "medicineList",
                column: "Article",
                principalTable: "Medicine",
                principalColumn: "Article",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
