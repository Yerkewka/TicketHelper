using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class RemoveRouteIdFromTrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Routes_RouteId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Trains_RouteId",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Trains");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TrainId",
                table: "Routes",
                column: "TrainId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TrainId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Trains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trains_RouteId",
                table: "Trains",
                column: "RouteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Routes_RouteId",
                table: "Trains",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
