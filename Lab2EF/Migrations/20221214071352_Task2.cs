using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class Task2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pharmacist",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shopper",
                keyColumn: "phoneNum",
                keyValue: "0930991212");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pharmacist",
                columns: new[] { "ID", "Discriminator", "Name" },
                values: new object[] { 2, "Pharmacist", "Belenko Nikola Petrovich" });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "ID", "Name", "licenseNum" },
                values: new object[] { 2, "Bayer", 123f });

            migrationBuilder.InsertData(
                table: "Shopper",
                columns: new[] { "phoneNum", "ID_discountcard", "discountValue" },
                values: new object[] { "0930991212", null, null });
        }
    }
}
