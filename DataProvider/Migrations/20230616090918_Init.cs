using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoinTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogBrands_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPurshared",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPurshared = table.Column<int>(type: "int", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: false),
                    Withdrawal = table.Column<double>(type: "float", nullable: false),
                    OverDraft = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPurshared", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionPurshared_CatalogBrands_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinTypeTransactionPurshared",
                columns: table => new
                {
                    CoinsRecievedId = table.Column<int>(type: "int", nullable: false),
                    TransactionPursharedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinTypeTransactionPurshared", x => new { x.CoinsRecievedId, x.TransactionPursharedId });
                    table.ForeignKey(
                        name: "FK_CoinTypeTransactionPurshared_CoinTypes_CoinsRecievedId",
                        column: x => x.CoinsRecievedId,
                        principalTable: "CoinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinTypeTransactionPurshared_TransactionPurshared_TransactionPursharedId",
                        column: x => x.TransactionPursharedId,
                        principalTable: "TransactionPurshared",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinTypeTransactionPurshared1",
                columns: table => new
                {
                    CoinsReturnedId = table.Column<int>(type: "int", nullable: false),
                    TransactionPurshared1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinTypeTransactionPurshared1", x => new { x.CoinsReturnedId, x.TransactionPurshared1Id });
                    table.ForeignKey(
                        name: "FK_CoinTypeTransactionPurshared1_CoinTypes_CoinsReturnedId",
                        column: x => x.CoinsReturnedId,
                        principalTable: "CoinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinTypeTransactionPurshared1_TransactionPurshared_TransactionPurshared1Id",
                        column: x => x.TransactionPurshared1Id,
                        principalTable: "TransactionPurshared",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogBrands_Name",
                table: "CatalogBrands",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogBrandId",
                table: "CatalogItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTypes_Name",
                table: "CoinTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTypeTransactionPurshared_TransactionPursharedId",
                table: "CoinTypeTransactionPurshared",
                column: "TransactionPursharedId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTypeTransactionPurshared1_TransactionPurshared1Id",
                table: "CoinTypeTransactionPurshared1",
                column: "TransactionPurshared1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPurshared_CatalogBrandId",
                table: "TransactionPurshared",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPurshared_Created",
                table: "TransactionPurshared",
                column: "Created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItems");

            migrationBuilder.DropTable(
                name: "CoinTypeTransactionPurshared");

            migrationBuilder.DropTable(
                name: "CoinTypeTransactionPurshared1");

            migrationBuilder.DropTable(
                name: "ErrorDetails");

            migrationBuilder.DropTable(
                name: "CoinTypes");

            migrationBuilder.DropTable(
                name: "TransactionPurshared");

            migrationBuilder.DropTable(
                name: "CatalogBrands");
        }
    }
}
