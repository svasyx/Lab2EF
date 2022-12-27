using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class NewTable11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_goodsInStorageplace",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "goodsInStorageplace",
                table: "Medicine");

            migrationBuilder.AlterColumn<float>(
                name: "medicineArticle",
                table: "GoodsInStorage",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsInStorage_medicineArticle",
                table: "GoodsInStorage",
                column: "medicineArticle",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsInStorage_Medicine_medicineArticle",
                table: "GoodsInStorage",
                column: "medicineArticle",
                principalTable: "Medicine",
                principalColumn: "Article",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsInStorage_Medicine_medicineArticle",
                table: "GoodsInStorage");

            migrationBuilder.DropIndex(
                name: "IX_GoodsInStorage_medicineArticle",
                table: "GoodsInStorage");

            migrationBuilder.AddColumn<int>(
                name: "goodsInStorageplace",
                table: "Medicine",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "medicineArticle",
                table: "GoodsInStorage",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_goodsInStorageplace",
                table: "Medicine",
                column: "goodsInStorageplace");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageplace",
                table: "Medicine",
                column: "goodsInStorageplace",
                principalTable: "GoodsInStorage",
                principalColumn: "place");
        }
    }
}
