using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItemTransactionPurshared");

            migrationBuilder.AddColumn<int>(
                name: "Transaction",
                table: "CatalogItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_Transaction",
                table: "CatalogItems",
                column: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_TransactionPurshared_Transaction",
                table: "CatalogItems",
                column: "Transaction",
                principalTable: "TransactionPurshared",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_TransactionPurshared_Transaction",
                table: "CatalogItems");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItems_Transaction",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "Transaction",
                table: "CatalogItems");

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
    }
}
