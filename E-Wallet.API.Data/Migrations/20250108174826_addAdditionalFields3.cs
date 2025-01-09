using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAdditionalFields3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Recharges_RechargeId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_RechargeId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "RechargeId",
                table: "Wallets");

            migrationBuilder.AddColumn<int>(
                name: "RechargePointId",
                table: "Recharges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Recharges",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4073f113-a5c1-4a9a-b2a1-6ae453639443", "AQAAAAIAAYagAAAAENynxW7apDIGKyJiU2dPDTCwSNF8dC5+6s0K1o7b1c2vC7iwxOy0u8Nled/5B7H74A==", "d934dda0-e990-43f6-93c3-275de41e9d94" });

            migrationBuilder.CreateIndex(
                name: "IX_Recharges_RechargePointId",
                table: "Recharges",
                column: "RechargePointId");

            migrationBuilder.CreateIndex(
                name: "IX_Recharges_WalletId",
                table: "Recharges",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recharges_RechargePoints_RechargePointId",
                table: "Recharges",
                column: "RechargePointId",
                principalTable: "RechargePoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recharges_Wallets_WalletId",
                table: "Recharges",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recharges_RechargePoints_RechargePointId",
                table: "Recharges");

            migrationBuilder.DropForeignKey(
                name: "FK_Recharges_Wallets_WalletId",
                table: "Recharges");

            migrationBuilder.DropIndex(
                name: "IX_Recharges_RechargePointId",
                table: "Recharges");

            migrationBuilder.DropIndex(
                name: "IX_Recharges_WalletId",
                table: "Recharges");

            migrationBuilder.DropColumn(
                name: "RechargePointId",
                table: "Recharges");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Recharges");

            migrationBuilder.AddColumn<int>(
                name: "RechargeId",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27c3803f-1c92-4e06-931f-ee0ae08944ca", "AQAAAAIAAYagAAAAELtB6RkcT61g+2Ra+wkw0H0mfcqLUR4PrgpdoWr/MaY2E36K2FaKXPpWVMPUhPgoJA==", "05ad4e9a-d194-4a21-8515-a9ea37b94d35" });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_RechargeId",
                table: "Wallets",
                column: "RechargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Recharges_RechargeId",
                table: "Wallets",
                column: "RechargeId",
                principalTable: "Recharges",
                principalColumn: "Id");
        }
    }
}
