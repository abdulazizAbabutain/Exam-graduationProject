using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.web.Migrations
{
    public partial class AddCorrectAnswerToAnswerSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswer",
                table: "AnswerSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "AnswerSheets");
        }
    }
}
