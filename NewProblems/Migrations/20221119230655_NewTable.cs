using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewProblems.Migrations
{
    public partial class NewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsInStudyPractise = table.Column<int>(type: "int", nullable: false),
                    InOurGymFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialistIn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachId);
                });

            migrationBuilder.CreateTable(
                name: "CoachInvites",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfPostMan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachInvites", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfExcersice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repeats = table.Column<int>(type: "int", nullable: false),
                    ActionsPerRepeat = table.Column<int>(type: "int", nullable: false),
                    CreatedForWho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "CoachInvites",
                columns: new[] { "ID", "CoachName", "NameOfPostMan", "RequestStatus" },
                values: new object[] { 1, "He", null, "E" });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "CoachId", "Age", "CoachName", "Gender", "InOurGymFrom", "SpecialistIn", "YearsInStudyPractise" },
                values: new object[] { 1, 53, "Igor", "Helicopter", new DateTime(2022, 11, 20, 2, 6, 54, 802, DateTimeKind.Local).AddTicks(5642), "Hight weight tooks up", 23 });

            migrationBuilder.InsertData(
                table: "TrainingsList",
                columns: new[] { "ID", "ActionsPerRepeat", "CoachName", "CreatedForWho", "Repeats", "TypeOfExcersice" },
                values: new object[] { 1, 23, "Igor", "owner", 2, "Push Ups" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Login", "Password", "Permissions" },
                values: new object[] { 1, "owner", "owner", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "CoachInvites");

            migrationBuilder.DropTable(
                name: "TrainingsList");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
