using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "placeIDID",
                table: "Medicine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoodsInStorage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsInStorage", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_placeIDID",
                table: "Medicine",
                column: "placeIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_GoodsInStorage_placeIDID",
                table: "Medicine",
                column: "placeIDID",
                principalTable: "GoodsInStorage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_GoodsInStorage_placeIDID",
                table: "Medicine");

            migrationBuilder.DropTable(
                name: "GoodsInStorage");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_placeIDID",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "placeIDID",
                table: "Medicine");
        }
    }
}
