using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courtbookingAPIREST.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameClubScheduleExceptionToOverride : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "club_schedule_exceptions",
                newName: "club_schedule_overrides");

            migrationBuilder.RenameColumn(
                name: "club_schedule_exceptions_id",
                table: "club_schedule_overrides",
                newName: "club_schedule_overrides_id");

            migrationBuilder.RenameIndex(
                name: "IX_club_schedule_exceptions_club_id",
                table: "club_schedule_overrides",
                newName: "IX_club_schedule_overrides_club_id");

            migrationBuilder.Sql("ALTER TABLE club_schedule_overrides RENAME CONSTRAINT \"PK_club_schedule_exceptions\" TO \"PK_club_schedule_overrides\";");
            migrationBuilder.Sql("ALTER TABLE club_schedule_overrides RENAME CONSTRAINT \"FK_club_schedule_exceptions_clubs_club_id\" TO \"FK_club_schedule_overrides_clubs_club_id\";");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE club_schedule_exceptions RENAME CONSTRAINT \"PK_club_schedule_overrides\" TO \"PK_club_schedule_exceptions\";");
            migrationBuilder.Sql("ALTER TABLE club_schedule_exceptions RENAME CONSTRAINT \"FK_club_schedule_overrides_clubs_club_id\" TO \"FK_club_schedule_exceptions_clubs_club_id\";");

            migrationBuilder.RenameIndex(
                name: "IX_club_schedule_overrides_club_id",
                table: "club_schedule_exceptions",
                newName: "IX_club_schedule_exceptions_club_id");

            migrationBuilder.RenameColumn(
                name: "club_schedule_overrides_id",
                table: "club_schedule_exceptions",
                newName: "club_schedule_exceptions_id");

            migrationBuilder.RenameTable(
                name: "club_schedule_overrides",
                newName: "club_schedule_exceptions");
        }
    }
}
