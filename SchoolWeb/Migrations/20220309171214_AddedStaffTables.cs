using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWeb.Migrations
{
    public partial class AddedStaffTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ogeResults",
                table: "ogeResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_egeResults",
                table: "egeResults");

            migrationBuilder.RenameTable(
                name: "ogeResults",
                newName: "OgeResults");

            migrationBuilder.RenameTable(
                name: "egeResults",
                newName: "EgeResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OgeResults",
                table: "OgeResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EgeResults",
                table: "EgeResults",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SchoolAdministration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAdministration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    HasHighEdu = table.Column<int>(type: "int", nullable: false),
                    HasHighQuality = table.Column<int>(type: "int", nullable: false),
                    HasFirstQuality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolStaff", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolAdministration");

            migrationBuilder.DropTable(
                name: "SchoolStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OgeResults",
                table: "OgeResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EgeResults",
                table: "EgeResults");

            migrationBuilder.RenameTable(
                name: "OgeResults",
                newName: "ogeResults");

            migrationBuilder.RenameTable(
                name: "EgeResults",
                newName: "egeResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ogeResults",
                table: "ogeResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_egeResults",
                table: "egeResults",
                column: "Id");
        }
    }
}
