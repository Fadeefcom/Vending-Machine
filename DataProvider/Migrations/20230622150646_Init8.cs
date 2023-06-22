using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinRecieved_CoinTypes_CoinId",
                table: "CoinRecieved");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinRecieved_TransactionPurshared_TransactionId",
                table: "CoinRecieved");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinReturned_CoinTypes_CoinId",
                table: "CoinReturned");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinReturned_TransactionPurshared_TransactionId",
                table: "CoinReturned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinReturned",
                table: "CoinReturned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinRecieved",
                table: "CoinRecieved");

            migrationBuilder.RenameTable(
                name: "CoinReturned",
                newName: "CoinReturneds");

            migrationBuilder.RenameTable(
                name: "CoinRecieved",
                newName: "CoinRecieveds");

            migrationBuilder.RenameIndex(
                name: "IX_CoinReturned_TransactionId",
                table: "CoinReturneds",
                newName: "IX_CoinReturneds_TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinReturned_CoinId",
                table: "CoinReturneds",
                newName: "IX_CoinReturneds_CoinId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinRecieved_TransactionId",
                table: "CoinRecieveds",
                newName: "IX_CoinRecieveds_TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinRecieved_CoinId",
                table: "CoinRecieveds",
                newName: "IX_CoinRecieveds_CoinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinReturneds",
                table: "CoinReturneds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinRecieveds",
                table: "CoinRecieveds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinRecieveds_CoinTypes_CoinId",
                table: "CoinRecieveds",
                column: "CoinId",
                principalTable: "CoinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoinRecieveds_TransactionPurshared_TransactionId",
                table: "CoinRecieveds",
                column: "TransactionId",
                principalTable: "TransactionPurshared",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoinReturneds_CoinTypes_CoinId",
                table: "CoinReturneds",
                column: "CoinId",
                principalTable: "CoinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoinReturneds_TransactionPurshared_TransactionId",
                table: "CoinReturneds",
                column: "TransactionId",
                principalTable: "TransactionPurshared",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinRecieveds_CoinTypes_CoinId",
                table: "CoinRecieveds");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinRecieveds_TransactionPurshared_TransactionId",
                table: "CoinRecieveds");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinReturneds_CoinTypes_CoinId",
                table: "CoinReturneds");

            migrationBuilder.DropForeignKey(
                name: "FK_CoinReturneds_TransactionPurshared_TransactionId",
                table: "CoinReturneds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinReturneds",
                table: "CoinReturneds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinRecieveds",
                table: "CoinRecieveds");

            migrationBuilder.RenameTable(
                name: "CoinReturneds",
                newName: "CoinReturned");

            migrationBuilder.RenameTable(
                name: "CoinRecieveds",
                newName: "CoinRecieved");

            migrationBuilder.RenameIndex(
                name: "IX_CoinReturneds_TransactionId",
                table: "CoinReturned",
                newName: "IX_CoinReturned_TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinReturneds_CoinId",
                table: "CoinReturned",
                newName: "IX_CoinReturned_CoinId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinRecieveds_TransactionId",
                table: "CoinRecieved",
                newName: "IX_CoinRecieved_TransactionId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinRecieveds_CoinId",
                table: "CoinRecieved",
                newName: "IX_CoinRecieved_CoinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinReturned",
                table: "CoinReturned",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinRecieved",
                table: "CoinRecieved",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinRecieved_CoinTypes_CoinId",
                table: "CoinRecieved",
                column: "CoinId",
                principalTable: "CoinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoinRecieved_TransactionPurshared_TransactionId",
                table: "CoinRecieved",
                column: "TransactionId",
                principalTable: "TransactionPurshared",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoinReturned_CoinTypes_CoinId",
                table: "CoinReturned",
                column: "CoinId",
                principalTable: "CoinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoinReturned_TransactionPurshared_TransactionId",
                table: "CoinReturned",
                column: "TransactionId",
                principalTable: "TransactionPurshared",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
