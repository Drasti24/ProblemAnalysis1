using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatePickerHint.Migrations
{
    /// <inheritdoc />
    public partial class SeedProgramOfStudy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProgramOfStudies",
                columns: new[] { "ProgramOfStudyId", "Name" },
                values: new object[,]
                {
                    { "BACS", "Bachelor of Applied Computer Science" },
                    { "CPA", "Computer Programmer Analyst" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgramOfStudies",
                keyColumn: "ProgramOfStudyId",
                keyValue: "BACS");

            migrationBuilder.DeleteData(
                table: "ProgramOfStudies",
                keyColumn: "ProgramOfStudyId",
                keyValue: "CPA");
        }
    }
}
