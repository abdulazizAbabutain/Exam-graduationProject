using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.web.Migrations
{
    public partial class addAnswerSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerSheet",
                columns: table => new
                {
                    AnswerSheet_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueastionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    StudentAnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSheet", x => x.AnswerSheet_Id);
                    table.ForeignKey(
                        name: "FK_AnswerSheet_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Question_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerSheet_StudentAnswers_StudentAnswerId",
                        column: x => x.StudentAnswerId,
                        principalTable: "StudentAnswers",
                        principalColumn: "Student_Answer_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheet_QuestionId",
                table: "AnswerSheet",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheet_StudentAnswerId",
                table: "AnswerSheet",
                column: "StudentAnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerSheet");
        }
    }
}
