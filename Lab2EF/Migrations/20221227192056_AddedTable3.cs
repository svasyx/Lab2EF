using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine",
                column: "goodsInStorageID",
                principalTable: "GoodsInStorage",
                principalColumn: "ID");
        }
    }
}
