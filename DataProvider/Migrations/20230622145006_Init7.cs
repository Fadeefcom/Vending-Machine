using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CoinRecieved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinRecieved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinRecieved_CoinTypes_CoinId",
                        column: x => x.CoinId,
                        principalTable: "CoinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinRecieved_TransactionPurshared_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TransactionPurshared",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinReturned",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinReturned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinReturned_CoinTypes_CoinId",
                        column: x => x.CoinId,
                        principalTable: "CoinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinReturned_TransactionPurshared_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "TransactionPurshared",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinRecieved_CoinId",
                table: "CoinRecieved",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinRecieved_TransactionId",
                table: "CoinRecieved",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinReturned_CoinId",
                table: "CoinReturned",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinReturned_TransactionId",
                table: "CoinReturned",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinRecieved");

            migrationBuilder.DropTable(
                name: "CoinReturned");

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
    }
}
