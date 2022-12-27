using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_placeIDID",
                table: "Medicine");

            migrationBuilder.RenameColumn(
                name: "placeIDID",
                table: "Medicine",
                newName: "goodsInStorageID");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_placeIDID",
                table: "Medicine",
                newName: "IX_Medicine_goodsInStorageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine",
                column: "goodsInStorageID",
                principalTable: "GoodsInStorage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine");

            migrationBuilder.RenameColumn(
                name: "goodsInStorageID",
                table: "Medicine",
                newName: "placeIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_goodsInStorageID",
                table: "Medicine",
                newName: "IX_Medicine_placeIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_placeIDID",
                table: "Medicine",
                column: "placeIDID",
                principalTable: "GoodsInStorage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
