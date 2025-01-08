using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewFields1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Wallets",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19f7d9f4-b571-4211-8599-8aa03c7e3b43", "AQAAAAIAAYagAAAAEOWp04/gbatTwUELro0Pj7nmTN4vlFNzP0awgQukDNpKTWD+i29SLiBsH1gyJhLuHw==", "295cfc48-887d-4448-af44-da7a4aa0620e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Wallets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d42d5561-f683-400f-b145-3cbf059a64ba", "AQAAAAIAAYagAAAAEDpI1SxzR0NIiPzGjMrOZdPB712mG3iNSN1FEhnCC85vuLL5IfyZ5Q1Qa5ySGCw2wA==", "139df047-fb32-4fe3-a286-38024dced146" });
        }
    }
}
