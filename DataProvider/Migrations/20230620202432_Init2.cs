using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionPurshared_CatalogBrands_CatalogBrandId",
                table: "TransactionPurshared");

            migrationBuilder.DropIndex(
                name: "IX_TransactionPurshared_CatalogBrandId",
                table: "TransactionPurshared");

            migrationBuilder.DropColumn(
                name: "CatalogBrandId",
                table: "TransactionPurshared");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogBrandTransactionPurshared");

            migrationBuilder.AddColumn<int>(
                name: "CatalogBrandId",
                table: "TransactionPurshared",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPurshared_CatalogBrandId",
                table: "TransactionPurshared",
                column: "CatalogBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionPurshared_CatalogBrands_CatalogBrandId",
                table: "TransactionPurshared",
                column: "CatalogBrandId",
                principalTable: "CatalogBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
