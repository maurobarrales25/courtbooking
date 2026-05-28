using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courtbookingAPIREST.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "courts",
                newName: "court_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "court_time_slots",
                newName: "court_time_slots_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "court_operating_schedules",
                newName: "court_operating_schedules_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "club_schedules",
                newName: "club_schedules_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "club_schedule_exceptions",
                newName: "club_schedule_exceptions_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "court_id",
                table: "courts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "court_time_slots_id",
                table: "court_time_slots",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "court_operating_schedules_id",
                table: "court_operating_schedules",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "club_schedules_id",
                table: "club_schedules",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "club_schedule_exceptions_id",
                table: "club_schedule_exceptions",
                newName: "id");
        }
    }
}
