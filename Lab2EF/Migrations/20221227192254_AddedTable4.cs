using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine");

            migrationBuilder.RenameColumn(
                name: "goodsInStorageID",
                table: "Medicine",
                newName: "goodsInStorageplace");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_goodsInStorageID",
                table: "Medicine",
                newName: "IX_Medicine_goodsInStorageplace");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "GoodsInStorage",
                newName: "place");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine",
                column: "goodsInStorageplace",
                principalTable: "GoodsInStorage",
                principalColumn: "place",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine");

            migrationBuilder.RenameColumn(
                name: "goodsInStorageplace",
                table: "Medicine",
                newName: "goodsInStorageID");

            migrationBuilder.RenameIndex(
                name: "IX_Medicine_goodsInStorageplace",
                table: "Medicine",
                newName: "IX_Medicine_goodsInStorageID");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "GoodsInStorage",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine",
                column: "goodsInStorageID",
                principalTable: "GoodsInStorage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
