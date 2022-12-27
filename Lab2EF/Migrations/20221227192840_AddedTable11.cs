using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine",
                column: "goodsInStorageplace",
                principalTable: "GoodsInStorage",
                principalColumn: "place");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine",
                column: "goodsInStorageplace",
                principalTable: "GoodsInStorage",
                principalColumn: "place",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
