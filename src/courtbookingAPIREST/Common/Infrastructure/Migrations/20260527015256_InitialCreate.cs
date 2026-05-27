using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courtbookingAPIREST.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clubs",
                columns: table => new
                {
                    club_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    state = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    neighborhood = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clubs", x => x.club_id);
                });

            migrationBuilder.CreateTable(
                name: "court_time_slots",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    court_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    start = table.Column<TimeSpan>(type: "interval", nullable: false),
                    end = table.Column<TimeSpan>(type: "interval", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_court_time_slots", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.state_id);
                });

            migrationBuilder.CreateTable(
                name: "club_schedule_exceptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    is_closed = table.Column<bool>(type: "boolean", nullable: false),
                    opening_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    club_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club_schedule_exceptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_club_schedule_exceptions_clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "clubs",
                        principalColumn: "club_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "club_schedules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_of_week = table.Column<string>(type: "text", nullable: false),
                    opening_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    closing_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club_schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_club_schedules_clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "clubs",
                        principalColumn: "club_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    slot_duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    club_id = table.Column<Guid>(type: "uuid", nullable: false),
                    overrides_club = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courts", x => x.id);
                    table.ForeignKey(
                        name: "FK_courts_clubs_club_id",
                        column: x => x.club_id,
                        principalTable: "clubs",
                        principalColumn: "club_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    state_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_cities_states_state_id",
                        column: x => x.state_id,
                        principalTable: "states",
                        principalColumn: "state_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "court_operating_schedules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_of_week = table.Column<string>(type: "text", nullable: false),
                    opening_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    closing_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    court_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_court_operating_schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_court_operating_schedules_courts_court_id",
                        column: x => x.court_id,
                        principalTable: "courts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_state_id",
                table: "cities",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_club_schedule_exceptions_club_id",
                table: "club_schedule_exceptions",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_club_schedules_club_id",
                table: "club_schedules",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_court_operating_schedules_court_id",
                table: "court_operating_schedules",
                column: "court_id");

            migrationBuilder.CreateIndex(
                name: "IX_court_time_slots_court_id_date",
                table: "court_time_slots",
                columns: new[] { "court_id", "date" });

            migrationBuilder.CreateIndex(
                name: "IX_courts_club_id",
                table: "courts",
                column: "club_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "club_schedule_exceptions");

            migrationBuilder.DropTable(
                name: "club_schedules");

            migrationBuilder.DropTable(
                name: "court_operating_schedules");

            migrationBuilder.DropTable(
                name: "court_time_slots");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "courts");

            migrationBuilder.DropTable(
                name: "clubs");
        }
    }
}
