using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class AddNameColumnToTrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trains",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trains");
        }
    }
}
