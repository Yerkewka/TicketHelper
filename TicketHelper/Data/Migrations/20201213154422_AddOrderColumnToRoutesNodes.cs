using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class AddOrderColumnToRoutesNodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "RoutesNodes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "RoutesNodes");
        }
    }
}
