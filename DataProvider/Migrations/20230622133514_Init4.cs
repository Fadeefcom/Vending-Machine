using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogBrandTransactionPurshared");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CatalogItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CatalogItemTransactionPurshared",
                columns: table => new
                {
                    CatalogItemsId = table.Column<int>(type: "int", nullable: false),
                    TransactionPursharedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemTransactionPurshared", x => new { x.CatalogItemsId, x.TransactionPursharedId });
                    table.ForeignKey(
                        name: "FK_CatalogItemTransactionPurshared_CatalogItems_CatalogItemsId",
                        column: x => x.CatalogItemsId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItemTransactionPurshared_TransactionPurshared_TransactionPursharedId",
                        column: x => x.TransactionPursharedId,
                        principalTable: "TransactionPurshared",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemTransactionPurshared_TransactionPursharedId",
                table: "CatalogItemTransactionPurshared",
                column: "TransactionPursharedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItemTransactionPurshared");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CatalogItems");

            migrationBuilder.CreateTable(
                name: "CatalogBrandTransactionPurshared",
                columns: table => new
                {
                    CatalogBrandsId = table.Column<int>(type: "int", nullable: false),
                    TransactionPursharedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrandTransactionPurshared", x => new { x.CatalogBrandsId, x.TransactionPursharedId });
                    table.ForeignKey(
                        name: "FK_CatalogBrandTransactionPurshared_CatalogBrands_CatalogBrandsId",
                        column: x => x.CatalogBrandsId,
                        principalTable: "CatalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogBrandTransactionPurshared_TransactionPurshared_TransactionPursharedId",
                        column: x => x.TransactionPursharedId,
                        principalTable: "TransactionPurshared",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogBrandTransactionPurshared_TransactionPursharedId",
                table: "CatalogBrandTransactionPurshared",
                column: "TransactionPursharedId");
        }
    }
}
