using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vizallas.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_872 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vizallas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VizallaS = table.Column<int>(type: "INTEGER", nullable: false),
                    Varos = table.Column<string>(type: "TEXT", nullable: false),
                    Folyo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizallas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vizallas");
        }
    }
}
