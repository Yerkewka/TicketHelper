using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class AddIndexTrainIdStationIdDateToSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedule_Date",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TrainId",
                table: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StationId",
                table: "Schedule",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainId_StationId_Date",
                table: "Schedule",
                columns: new[] { "TrainId", "StationId", "Date" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Stations_StationId",
                table: "Schedule",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Stations_StationId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_StationId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TrainId_StationId_Date",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "Schedule");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_Date",
                table: "Schedule",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainId",
                table: "Schedule",
                column: "TrainId");
        }
    }
}
