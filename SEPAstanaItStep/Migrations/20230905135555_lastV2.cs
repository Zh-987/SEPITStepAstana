using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEPAstanaItStep.Migrations
{
    /// <inheritdoc />
    public partial class lastV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_companies_Companyid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CompnayId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Companyid",
                table: "users",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_users_Companyid",
                table: "users",
                newName: "IX_users_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_companies_CompanyId",
                table: "users",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_companies_CompanyId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "users",
                newName: "Companyid");

            migrationBuilder.RenameIndex(
                name: "IX_users_CompanyId",
                table: "users",
                newName: "IX_users_Companyid");

            migrationBuilder.AddColumn<int>(
                name: "CompnayId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_companies_Companyid",
                table: "users",
                column: "Companyid",
                principalTable: "companies",
                principalColumn: "id");
        }
    }
}
