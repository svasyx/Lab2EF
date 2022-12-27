using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedNamings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Pharmacist_pharmacistID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinemedicineList_Medicine_listifmedlistsArticle",
                table: "MedicinemedicineList");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinemedicineList_medicineList_medicineListsID",
                table: "MedicinemedicineList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicinemedicineList",
                table: "MedicinemedicineList");

            migrationBuilder.RenameTable(
                name: "MedicinemedicineList",
                newName: "ListToList");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinemedicineList_medicineListsID",
                table: "ListToList",
                newName: "IX_ListToList_medicineListsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListToList",
                table: "ListToList",
                columns: new[] { "listifmedlistsArticle", "medicineListsID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Pharmacist_pharmacistID",
                table: "Bill",
                column: "pharmacistID",
                principalTable: "Pharmacist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListToList_Medicine_listifmedlistsArticle",
                table: "ListToList",
                column: "listifmedlistsArticle",
                principalTable: "Medicine",
                principalColumn: "Article",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListToList_medicineList_medicineListsID",
                table: "ListToList",
                column: "medicineListsID",
                principalTable: "medicineList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Pharmacist_pharmacistID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_ListToList_Medicine_listifmedlistsArticle",
                table: "ListToList");

            migrationBuilder.DropForeignKey(
                name: "FK_ListToList_medicineList_medicineListsID",
                table: "ListToList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListToList",
                table: "ListToList");

            migrationBuilder.RenameTable(
                name: "ListToList",
                newName: "MedicinemedicineList");

            migrationBuilder.RenameIndex(
                name: "IX_ListToList_medicineListsID",
                table: "MedicinemedicineList",
                newName: "IX_MedicinemedicineList_medicineListsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicinemedicineList",
                table: "MedicinemedicineList",
                columns: new[] { "listifmedlistsArticle", "medicineListsID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Pharmacist_pharmacistID",
                table: "Bill",
                column: "pharmacistID",
                principalTable: "Pharmacist",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinemedicineList_Medicine_listifmedlistsArticle",
                table: "MedicinemedicineList",
                column: "listifmedlistsArticle",
                principalTable: "Medicine",
                principalColumn: "Article",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinemedicineList_medicineList_medicineListsID",
                table: "MedicinemedicineList",
                column: "medicineListsID",
                principalTable: "medicineList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
