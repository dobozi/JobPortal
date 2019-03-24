using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsPortal.Data.Migrations
{
    public partial class AddDeleteToRecruiter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Recruiters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CompanyRecruiter",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    RecruiterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRecruiter", x => new { x.CompanyId, x.RecruiterId });
                    table.ForeignKey(
                        name: "FK_CompanyRecruiter_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyRecruiter_Recruiters_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "Recruiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRecruiter_RecruiterId",
                table: "CompanyRecruiter",
                column: "RecruiterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyRecruiter");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Recruiters");
        }
    }
}
