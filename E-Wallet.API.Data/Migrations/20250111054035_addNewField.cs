using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecharged",
                table: "Recharges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c18d522b-38d8-420f-b32c-b52f8fa5a163", "AQAAAAIAAYagAAAAELrQf12jtSG/bMyTsPiei0JonWWXA7lganjWQBHOsAiQOsWCFvNP4c2ILwYNKJxUlA==", "0404ff13-3504-4212-8874-d9c9e79ec49b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecharged",
                table: "Recharges");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc03fad7-71a5-4f69-89aa-b15274d844cd", "AQAAAAIAAYagAAAAENzJwHFhEvjqmyUjAVB55Xebfv2flCRkoWTivosYr5hWbSvjt4EZAvQ60W7o5pH7EA==", "8a3ede46-7f15-4fb8-bac9-f33f7f755108" });
        }
    }
}
