using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBiz.Data.Migrations
{
    public partial class createdtableasdsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sliders");
        }
    }
}
