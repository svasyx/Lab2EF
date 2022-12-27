using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine");

            migrationBuilder.AlterColumn<int>(
                name: "goodsInStorageID",
                table: "Medicine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine",
                column: "goodsInStorageID",
                principalTable: "GoodsInStorage",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_goodsInStorageID",
                table: "Medicine");

            migrationBuilder.AlterColumn<int>(
                name: "goodsInStorageID",
                table: "Medicine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
