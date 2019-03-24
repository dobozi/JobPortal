using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsPortal.Data.Migrations
{
    public partial class RecruitersDataEntityUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Recruiters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Recruiters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Recruiters");
        }
    }
}
