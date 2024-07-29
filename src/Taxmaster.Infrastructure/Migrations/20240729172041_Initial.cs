using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taxmaster.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbDateRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxRate = table.Column<decimal>(type: "numeric", nullable: false),
                    MunicipalityId = table.Column<string>(type: "text", nullable: false),
                    UtcStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UtcEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDateRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbDateRule_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Municipalities",
                column: "Id",
                values: new object[]
                {
                    "aarhus",
                    "copenhagen"
                });

            migrationBuilder.InsertData(
                table: "DbDateRule",
                columns: new[] { "Id", "MunicipalityId", "TaxRate", "UtcEndTime", "UtcStartTime" },
                values: new object[,]
                {
                    { 1, "copenhagen", 0.2m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "copenhagen", 0.2m, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "copenhagen", 0.2m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "copenhagen", 0.2m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "copenhagen", 0.2m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "copenhagen", 0.2m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "copenhagen", 0.2m, new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, "copenhagen", 0.2m, new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "copenhagen", 0.2m, new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, "copenhagen", 0.2m, new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, "copenhagen", 0.2m, new DateTime(2031, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, "copenhagen", 0.2m, new DateTime(2032, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2031, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, "copenhagen", 0.2m, new DateTime(2033, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2032, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, "copenhagen", 0.2m, new DateTime(2034, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2033, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, "copenhagen", 0.2m, new DateTime(2035, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2034, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, "copenhagen", 0.2m, new DateTime(2036, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2035, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, "copenhagen", 0.2m, new DateTime(2037, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2036, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, "copenhagen", 0.2m, new DateTime(2038, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2037, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, "copenhagen", 0.2m, new DateTime(2039, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2038, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, "copenhagen", 0.2m, new DateTime(2040, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2039, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, "copenhagen", 0.4m, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, "copenhagen", 0.4m, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, "copenhagen", 0.4m, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, "copenhagen", 0.4m, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, "copenhagen", 0.4m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, "copenhagen", 0.4m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, "copenhagen", 0.4m, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, "copenhagen", 0.4m, new DateTime(2027, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2027, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, "copenhagen", 0.4m, new DateTime(2028, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2028, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, "copenhagen", 0.4m, new DateTime(2029, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2029, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 31, "copenhagen", 0.4m, new DateTime(2030, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2030, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 32, "copenhagen", 0.4m, new DateTime(2031, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2031, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 33, "copenhagen", 0.4m, new DateTime(2032, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2032, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 34, "copenhagen", 0.4m, new DateTime(2033, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2033, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 35, "copenhagen", 0.4m, new DateTime(2034, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2034, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 36, "copenhagen", 0.4m, new DateTime(2035, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2035, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 37, "copenhagen", 0.4m, new DateTime(2036, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2036, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 38, "copenhagen", 0.4m, new DateTime(2037, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2037, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 39, "copenhagen", 0.4m, new DateTime(2038, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2038, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 40, "copenhagen", 0.4m, new DateTime(2039, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2039, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 41, "copenhagen", 0.1m, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 42, "copenhagen", 0.1m, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 43, "copenhagen", 0.1m, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 44, "copenhagen", 0.1m, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 45, "copenhagen", 0.1m, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 46, "copenhagen", 0.1m, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 47, "copenhagen", 0.1m, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 48, "copenhagen", 0.1m, new DateTime(2027, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 49, "copenhagen", 0.1m, new DateTime(2028, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 50, "copenhagen", 0.1m, new DateTime(2029, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2029, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 51, "copenhagen", 0.1m, new DateTime(2030, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 52, "copenhagen", 0.1m, new DateTime(2031, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2031, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 53, "copenhagen", 0.1m, new DateTime(2032, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2032, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 54, "copenhagen", 0.1m, new DateTime(2033, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2033, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 55, "copenhagen", 0.1m, new DateTime(2034, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2034, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 56, "copenhagen", 0.1m, new DateTime(2035, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2035, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 57, "copenhagen", 0.1m, new DateTime(2036, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2036, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 58, "copenhagen", 0.1m, new DateTime(2037, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2037, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 59, "copenhagen", 0.1m, new DateTime(2038, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2038, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 60, "copenhagen", 0.1m, new DateTime(2039, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2039, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 61, "copenhagen", 0.1m, new DateTime(2020, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 62, "copenhagen", 0.1m, new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 63, "copenhagen", 0.1m, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 64, "copenhagen", 0.1m, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 65, "copenhagen", 0.1m, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 66, "copenhagen", 0.1m, new DateTime(2025, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 67, "copenhagen", 0.1m, new DateTime(2026, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 68, "copenhagen", 0.1m, new DateTime(2027, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2027, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 69, "copenhagen", 0.1m, new DateTime(2028, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2028, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 70, "copenhagen", 0.1m, new DateTime(2029, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2029, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 71, "copenhagen", 0.1m, new DateTime(2030, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2030, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 72, "copenhagen", 0.1m, new DateTime(2031, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2031, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 73, "copenhagen", 0.1m, new DateTime(2032, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2032, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 74, "copenhagen", 0.1m, new DateTime(2033, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2033, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 75, "copenhagen", 0.1m, new DateTime(2034, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2034, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 76, "copenhagen", 0.1m, new DateTime(2035, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2035, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 77, "copenhagen", 0.1m, new DateTime(2036, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2036, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 78, "copenhagen", 0.1m, new DateTime(2037, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2037, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 79, "copenhagen", 0.1m, new DateTime(2038, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2038, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 80, "copenhagen", 0.1m, new DateTime(2039, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2039, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbDateRule_MunicipalityId",
                table: "DbDateRule",
                column: "MunicipalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbDateRule");

            migrationBuilder.DropTable(
                name: "Municipalities");
        }
    }
}
