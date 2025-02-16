using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatePickerHint.Migrations
{
    /// <inheritdoc />
    public partial class NewInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ProgramOfStudies_ProgramOfStudyId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramOfStudies",
                table: "ProgramOfStudies");

            migrationBuilder.DropColumn(
                name: "ProgramOfStudyId",
                table: "ProgramOfStudies");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramOfStudyId",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProgramOfStudies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramOfStudies",
                table: "ProgramOfStudies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ProgramOfStudies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Programmer (CP)" },
                    { 2, "Bachelor of Applied Computer Science (BACS)" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "GPA", "LastName", "ProgramOfStudyId" },
                values: new object[,]
                {
                    { 1, new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart", 2.7000000000000002, "Simpson", 1 },
                    { 2, new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", 4.0, "Simpson", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ProgramOfStudies_ProgramOfStudyId",
                table: "Students",
                column: "ProgramOfStudyId",
                principalTable: "ProgramOfStudies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ProgramOfStudies_ProgramOfStudyId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramOfStudies",
                table: "ProgramOfStudies");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProgramOfStudies",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgramOfStudies",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProgramOfStudies");

            migrationBuilder.AlterColumn<string>(
                name: "ProgramOfStudyId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProgramOfStudyId",
                table: "ProgramOfStudies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramOfStudies",
                table: "ProgramOfStudies",
                column: "ProgramOfStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ProgramOfStudies_ProgramOfStudyId",
                table: "Students",
                column: "ProgramOfStudyId",
                principalTable: "ProgramOfStudies",
                principalColumn: "ProgramOfStudyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
