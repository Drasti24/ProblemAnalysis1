using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatePickerHint.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgramOfStudyId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProgramOfStudies",
                columns: table => new
                {
                    ProgramOfStudyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOfStudies", x => x.ProgramOfStudyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramOfStudyId",
                table: "Students",
                column: "ProgramOfStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ProgramOfStudies_ProgramOfStudyId",
                table: "Students",
                column: "ProgramOfStudyId",
                principalTable: "ProgramOfStudies",
                principalColumn: "ProgramOfStudyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ProgramOfStudies_ProgramOfStudyId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ProgramOfStudies");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProgramOfStudyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProgramOfStudyId",
                table: "Students");
        }
    }
}
