using Microsoft.EntityFrameworkCore.Migrations;

namespace Midterm_guestbook.Migrations
{
    public partial class addTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Guestbook",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Guestbook");
        }
    }
}
