using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinTypeTransactionPurshared");

            migrationBuilder.DropTable(
                name: "CoinTypeTransactionPurshared1");

            migrationBuilder.AddColumn<int>(
                name: "TransactionPursharedId",
                table: "CoinTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionPursharedId1",
                table: "CoinTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoinTypes_TransactionPursharedId",
                table: "CoinTypes",
                column: "TransactionPursharedId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTypes_TransactionPursharedId1",
                table: "CoinTypes",
                column: "TransactionPursharedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinTypes_TransactionPurshared_TransactionPursharedId",
                table: "CoinTypes",
                column: "TransactionPursharedId",
                principalTable: "TransactionPurshared",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinTypes_TransactionPurshared_TransactionPursharedId1",
                table: "CoinTypes",
                column: "TransactionPursharedId1",
                principalTable: "TransactionPurshared",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinTypes_TransactionPurshared_TransactionPursharedId",
                table: "CoinTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinTypes_TransactionPurshared_TransactionPursharedId1",
                table: "CoinTypes");

            migrationBuilder.DropIndex(
                name: "IX_CoinTypes_TransactionPursharedId",
                table: "CoinTypes");

            migrationBuilder.DropIndex(
                name: "IX_CoinTypes_TransactionPursharedId1",
                table: "CoinTypes");

            migrationBuilder.DropColumn(
                name: "TransactionPursharedId",
                table: "CoinTypes");

            migrationBuilder.DropColumn(
                name: "TransactionPursharedId1",
                table: "CoinTypes");

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
                name: "IX_CoinTypeTransactionPurshared_TransactionPursharedId",
                table: "CoinTypeTransactionPurshared",
                column: "TransactionPursharedId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTypeTransactionPurshared1_TransactionPurshared1Id",
                table: "CoinTypeTransactionPurshared1",
                column: "TransactionPurshared1Id");
        }
    }
}
