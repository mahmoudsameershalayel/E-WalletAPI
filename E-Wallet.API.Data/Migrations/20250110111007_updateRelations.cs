using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Wallet.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recharges_RechargePoints_RechargePointId",
                table: "Recharges");

            migrationBuilder.DropIndex(
                name: "IX_Recharges_RechargePointId",
                table: "Recharges");

            migrationBuilder.RenameColumn(
                name: "RechargePointId",
                table: "Recharges",
                newName: "RechargeWalletId");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Recharges",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Recharges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc03fad7-71a5-4f69-89aa-b15274d844cd", "AQAAAAIAAYagAAAAENzJwHFhEvjqmyUjAVB55Xebfv2flCRkoWTivosYr5hWbSvjt4EZAvQ60W7o5pH7EA==", "8a3ede46-7f15-4fb8-bac9-f33f7f755108" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Recharges");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Recharges");

            migrationBuilder.RenameColumn(
                name: "RechargeWalletId",
                table: "Recharges",
                newName: "RechargePointId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d67817e-fa79-46e5-902e-54763e0e06d3", "AQAAAAIAAYagAAAAEKjfGlp6GLeGrtoRC7nHwea8s3q9Z8n1PZH6TzhD+d3m485t4Z3MHqCF09sCxEJmkg==", "54d57114-402b-4ba0-bb17-1641cdde6500" });

            migrationBuilder.CreateIndex(
                name: "IX_Recharges_RechargePointId",
                table: "Recharges",
                column: "RechargePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recharges_RechargePoints_RechargePointId",
                table: "Recharges",
                column: "RechargePointId",
                principalTable: "RechargePoints",
                principalColumn: "Id");
        }
    }
}
