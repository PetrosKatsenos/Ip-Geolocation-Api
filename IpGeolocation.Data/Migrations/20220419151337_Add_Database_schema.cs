using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IpGeolocation.Data.Migrations
{
    public partial class Add_Database_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Geolocations");

            migrationBuilder.CreateTable(
                name: "GeolocationsCollections",
                schema: "Geolocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IPsTotalCount = table.Column<int>(type: "int", nullable: false),
                    IPsInsertedCount = table.Column<int>(type: "int", nullable: false),
                    IPsErrorCount = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    EntityCreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EntityModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeolocationsCollections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeolocationsCollections",
                schema: "Geolocations");
        }
    }
}
