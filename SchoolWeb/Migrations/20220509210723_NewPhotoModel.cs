using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWeb.Migrations
{
    public partial class NewPhotoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Photoes");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Photoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Photoes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Photoes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
