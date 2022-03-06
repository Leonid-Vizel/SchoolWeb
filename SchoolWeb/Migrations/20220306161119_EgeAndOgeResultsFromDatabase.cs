using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWeb.Migrations
{
    public partial class EgeAndOgeResultsFromDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "egeResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Russian = table.Column<float>(type: "real", nullable: false),
                    MathBase = table.Column<float>(type: "real", nullable: false),
                    MathProfi = table.Column<float>(type: "real", nullable: false),
                    History = table.Column<float>(type: "real", nullable: false),
                    SocialStudies = table.Column<float>(type: "real", nullable: false),
                    Physics = table.Column<float>(type: "real", nullable: false),
                    Chemistry = table.Column<float>(type: "real", nullable: false),
                    Geography = table.Column<float>(type: "real", nullable: false),
                    Biology = table.Column<float>(type: "real", nullable: false),
                    Informatics = table.Column<float>(type: "real", nullable: false),
                    English = table.Column<float>(type: "real", nullable: false),
                    Literature = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egeResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ogeResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Russian = table.Column<float>(type: "real", nullable: false),
                    Math = table.Column<float>(type: "real", nullable: false),
                    SocialStudies = table.Column<float>(type: "real", nullable: false),
                    English = table.Column<float>(type: "real", nullable: false),
                    Informatics = table.Column<float>(type: "real", nullable: false),
                    History = table.Column<float>(type: "real", nullable: false),
                    Biology = table.Column<float>(type: "real", nullable: false),
                    Chemistry = table.Column<float>(type: "real", nullable: false),
                    Geography = table.Column<float>(type: "real", nullable: false),
                    Physics = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogeResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "egeResults");

            migrationBuilder.DropTable(
                name: "ogeResults");
        }
    }
}
