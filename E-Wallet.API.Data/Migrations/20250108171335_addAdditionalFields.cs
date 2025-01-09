using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAdditionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RechargeCode",
                table: "RechargePoints");

            migrationBuilder.DropColumn(
                name: "RechargeCodeStatus",
                table: "RechargePoints");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19f7d9f4-b571-4211-8599-8aa03c7e3b43", "AQAAAAIAAYagAAAAEOWp04/gbatTwUELro0Pj7nmTN4vlFNzP0awgQukDNpKTWD+i29SLiBsH1gyJhLuHw==", "295cfc48-887d-4448-af44-da7a4aa0620e" });
        }
    }
}
