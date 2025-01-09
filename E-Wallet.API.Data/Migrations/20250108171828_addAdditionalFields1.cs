using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAdditionalFields1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RechargeCode",
                table: "RechargePoints");

            migrationBuilder.DropColumn(
                name: "RechargeCodeStatus",
                table: "RechargePoints");

            migrationBuilder.AddColumn<int>(
                name: "RechargeId",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RechargeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RechargeCodeStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recharges", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Recharges_RechargeId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "Recharges");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_RechargeId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "RechargeId",
                table: "Wallets");

            migrationBuilder.AddColumn<string>(
                name: "RechargeCode",
                table: "RechargePoints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RechargeCodeStatus",
                table: "RechargePoints",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65698134-6bd1-410f-8c2e-27a927c08c46", "AQAAAAIAAYagAAAAEKSQUjszmjycadKBUkaos0q9Hy6IbrbpuzipJ9GTQxWCWFnwZ9ZGd7dxzFbAXv9vGA==", "76d7b012-f33e-4e26-b7d8-da99561a0434" });
        }
    }
}
