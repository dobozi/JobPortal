using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsPortal.Data.Migrations
{
    public partial class JobEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkSchedule",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkplaceAddress",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkSchedule",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkplaceAddress",
                table: "Jobs");
        }
    }
}
