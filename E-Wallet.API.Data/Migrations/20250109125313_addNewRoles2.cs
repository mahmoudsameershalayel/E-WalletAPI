using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Customers_CustomerId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Wallets",
                newName: "WalletType");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Wallets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "userType" },
                values: new object[] { "7d67817e-fa79-46e5-902e-54763e0e06d3", "AQAAAAIAAYagAAAAEKjfGlp6GLeGrtoRC7nHwea8s3q9Z8n1PZH6TzhD+d3m485t4Z3MHqCF09sCxEJmkg==", "54d57114-402b-4ba0-bb17-1641cdde6500", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_ApplicationUserId",
                table: "Wallets",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AspNetUsers_ApplicationUserId",
                table: "Wallets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AspNetUsers_ApplicationUserId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_ApplicationUserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "userType",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "WalletType",
                table: "Wallets",
                newName: "CustomerId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50a8380b-cde6-406a-84c9-85740401231f", "AQAAAAIAAYagAAAAEBaMmBAV+h2TBeiJp17YUNb2+ogesJ9K0RE1TGNoPICKnUNzdg4ogn7WWIjE41JWGg==", "d031a7d9-15a6-47f4-8953-e347216e214a" });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallets",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Customers_CustomerId",
                table: "Wallets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
