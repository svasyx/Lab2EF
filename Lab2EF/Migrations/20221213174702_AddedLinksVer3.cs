using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedLinksVer3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_medicineList_medicineLID",
                table: "Medicine");

            migrationBuilder.RenameColumn(
                name: "medicineLID",
                table: "Medicine",
                newName: "listIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_medicineLID",
                table: "Medicine",
                newName: "IX_Medicine_listIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_medicineList_listIDID",
                table: "Medicine",
                column: "listIDID",
                principalTable: "medicineList",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_medicineList_listIDID",
                table: "Medicine");

            migrationBuilder.RenameColumn(
                name: "listIDID",
                table: "Medicine",
                newName: "medicineLID");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_listIDID",
                table: "Medicine",
                newName: "IX_Medicine_medicineLID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_medicineList_medicineLID",
                table: "Medicine",
                column: "medicineLID",
                principalTable: "medicineList",
                principalColumn: "ID");
        }
    }
}
