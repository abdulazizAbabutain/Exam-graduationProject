using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.web.Migrations
{
    public partial class AddPropToExamRoomsextion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UserEntedDate",
                table: "ExamRoomSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UserExitDate",
                table: "ExamRoomSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEntedDate",
                table: "ExamRoomSessions");

            migrationBuilder.DropColumn(
                name: "UserExitDate",
                table: "ExamRoomSessions");
        }
    }
}
