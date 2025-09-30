using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vizallas.Migrations
{
    /// <inheritdoc />
    public partial class SyncModel_20250930 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VizallaS",
                table: "Vizallas",
                newName: "Vizallas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vizallas",
                table: "Vizallas",
                newName: "VizallaS");
        }
    }
}
