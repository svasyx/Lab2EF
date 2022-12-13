using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2EF.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    licenseNum = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shopper",
                columns: table => new
                {
                    phoneNum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    discountValue = table.Column<float>(type: "real", nullable: true),
                    IDdiscountcard = table.Column<int>(name: "ID_discountcard", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopper", x => x.phoneNum);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pharmacistID = table.Column<int>(type: "int", nullable: true),
                    DiscCardID = table.Column<int>(type: "int", nullable: true),
                    finalPrice = table.Column<int>(type: "int", nullable: false),
                    TypeOfPay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateofPay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discValue = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bill_Pharmacist_pharmacistID",
                        column: x => x.pharmacistID,
                        principalTable: "Pharmacist",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Article = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    receipeneed = table.Column<bool>(type: "bit", nullable: false),
                    temperature = table.Column<float>(type: "real", nullable: false),
                    producerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Article);
                    table.ForeignKey(
                        name: "FK_Medicine_Producer_producerID",
                        column: x => x.producerID,
                        principalTable: "Producer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipe_Bill_BillID",
                        column: x => x.BillID,
                        principalTable: "Bill",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "medicineList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    unitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_medicineList_Bill_billID",
                        column: x => x.billID,
                        principalTable: "Bill",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicineList_Medicine_Article",
                        column: x => x.Article,
                        principalTable: "Medicine",
                        principalColumn: "Article",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_pharmacistID",
                table: "Bill",
                column: "pharmacistID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_producerID",
                table: "Medicine",
                column: "producerID");

            migrationBuilder.CreateIndex(
                name: "IX_medicineList_Article",
                table: "medicineList",
                column: "Article");

            migrationBuilder.CreateIndex(
                name: "IX_medicineList_billID",
                table: "medicineList",
                column: "billID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_BillID",
                table: "Recipe",
                column: "BillID",
                unique: true,
                filter: "[BillID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicineList");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Shopper");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Pharmacist");
        }
    }
}
