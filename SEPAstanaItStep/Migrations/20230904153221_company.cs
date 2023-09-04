using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEPAstanaItStep.Migrations
{
    /// <inheritdoc />
    public partial class company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Companyid",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompnayId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Companyid",
                table: "users",
                column: "Companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_companies_Companyid",
                table: "users",
                column: "Companyid",
                principalTable: "companies",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_companies_Companyid",
                table: "users");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropIndex(
                name: "IX_users_Companyid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Companyid",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CompnayId",
                table: "users");
        }
    }
}
