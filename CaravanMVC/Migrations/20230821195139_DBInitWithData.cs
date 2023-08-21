using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaravanMVC.Migrations
{
    /// <inheritdoc />
    public partial class DBInitWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wagons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    num_wheels = table.Column<int>(type: "integer", nullable: false),
                    covered = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wagons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    destination = table.Column<string>(type: "text", nullable: false),
                    wagon_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_passengers", x => x.id);
                    table.ForeignKey(
                        name: "fk_passengers_wagons_wagon_id",
                        column: x => x.wagon_id,
                        principalTable: "wagons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "wagons",
                columns: new[] { "id", "covered", "name", "num_wheels" },
                values: new object[,]
                {
                    { 1, true, "Wagon One", 4 },
                    { 2, false, "Wagon Two", 8 }
                });

            migrationBuilder.InsertData(
                table: "passengers",
                columns: new[] { "id", "age", "destination", "name", "wagon_id" },
                values: new object[,]
                {
                    { 1, 23, "The Gold Coast", "Joey", 1 },
                    { 2, 27, "The Gold Coast", "Cole", 1 },
                    { 3, 33, "The Gold Coast", "Jimy", 1 },
                    { 4, 53, "The Cold Mid-West", "Joseph", 2 },
                    { 5, 24, "The Cold Mid-West", "Seth", 2 },
                    { 6, 83, "The Cold Mid-West", "Gole", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_passengers_wagon_id",
                table: "passengers",
                column: "wagon_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "wagons");
        }
    }
}
