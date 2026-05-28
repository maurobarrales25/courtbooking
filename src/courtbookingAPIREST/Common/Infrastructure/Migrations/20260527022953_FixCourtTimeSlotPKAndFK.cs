using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courtbookingAPIREST.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCourtTimeSlotPKAndFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "court_time_slots_id",
                table: "court_time_slots",
                newName: "court_time_slot_id");

            migrationBuilder.AddForeignKey(
                name: "FK_court_time_slots_courts_court_id",
                table: "court_time_slots",
                column: "court_id",
                principalTable: "courts",
                principalColumn: "court_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_court_time_slots_courts_court_id",
                table: "court_time_slots");

            migrationBuilder.RenameColumn(
                name: "court_time_slot_id",
                table: "court_time_slots",
                newName: "court_time_slots_id");
        }
    }
}
