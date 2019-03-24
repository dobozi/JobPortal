using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsPortal.Data.Migrations
{
    public partial class UsersDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "Candidates",
                newName: "Adress");

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Candidates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Ext = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CVId",
                table: "Candidates",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Document_CVId",
                table: "Candidates",
                column: "CVId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Document_CVId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_CVId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Candidates",
                newName: "Identifier");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);
        }
    }
}
