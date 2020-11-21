using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class AddTicketScheduleCarriage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriages",
                columns: table => new
                {
                    CarriageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriages", x => x.CarriageId);
                    table.ForeignKey(
                        name: "FK_Carriages_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(nullable: false),
                    CarriageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Carriages_CarriageId",
                        column: x => x.CarriageId,
                        principalTable: "Carriages",
                        principalColumn: "CarriageId");
                    table.ForeignKey(
                        name: "FK_Tickets_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carriages_TrainId",
                table: "Carriages",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_Date",
                table: "Schedule",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainId",
                table: "Schedule",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CarriageId",
                table: "Tickets",
                column: "CarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScheduleId",
                table: "Tickets",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Carriages");

            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
