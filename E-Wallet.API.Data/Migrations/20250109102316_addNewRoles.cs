using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RechargePoints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "478543f7-8ce4-42de-afbf-59f706d72cf6", "478543f7-8ce4-42de-afbf-59f706d72cf6", "RechargePoint", "RECHARGEPOINT" },
                    { "786743f1-1ce8-73de-afbf-29f706d72cf6", "786743f1-1ce8-73de-afbf-29f706d72cf6", "Payment", "PAYMENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50a8380b-cde6-406a-84c9-85740401231f", "AQAAAAIAAYagAAAAEBaMmBAV+h2TBeiJp17YUNb2+ogesJ9K0RE1TGNoPICKnUNzdg4ogn7WWIjE41JWGg==", "d031a7d9-15a6-47f4-8953-e347216e214a" });

            migrationBuilder.CreateIndex(
                name: "IX_RechargePoints_ApplicationUserId",
                table: "RechargePoints",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ApplicationUserId",
                table: "Payments",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_ApplicationUserId",
                table: "Payments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RechargePoints_AspNetUsers_ApplicationUserId",
                table: "RechargePoints",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_ApplicationUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_RechargePoints_AspNetUsers_ApplicationUserId",
                table: "RechargePoints");

            migrationBuilder.DropIndex(
                name: "IX_RechargePoints_ApplicationUserId",
                table: "RechargePoints");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ApplicationUserId",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478543f7-8ce4-42de-afbf-59f706d72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "786743f1-1ce8-73de-afbf-29f706d72cf6");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RechargePoints");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4073f113-a5c1-4a9a-b2a1-6ae453639443", "AQAAAAIAAYagAAAAENynxW7apDIGKyJiU2dPDTCwSNF8dC5+6s0K1o7b1c2vC7iwxOy0u8Nled/5B7H74A==", "d934dda0-e990-43f6-93c3-275de41e9d94" });
        }
    }
}
