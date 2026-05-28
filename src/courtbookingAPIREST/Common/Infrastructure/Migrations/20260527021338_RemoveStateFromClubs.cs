using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courtbookingAPIREST.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStateFromClubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "neighborhood",
                table: "clubs");

            migrationBuilder.DropColumn(
                name: "state",
                table: "clubs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "neighborhood",
                table: "clubs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "clubs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
