using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.web.Migrations
{
    public partial class addAnswerSheetedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheet_Questions_QuestionId",
                table: "AnswerSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheet_StudentAnswers_StudentAnswerId",
                table: "AnswerSheet");

            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerSheet",
                table: "AnswerSheet");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSheet_StudentAnswerId",
                table: "AnswerSheet");

            migrationBuilder.DropColumn(
                name: "StudentAnswerId",
                table: "AnswerSheet");

            migrationBuilder.RenameTable(
                name: "AnswerSheet",
                newName: "AnswerSheets");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerSheet_QuestionId",
                table: "AnswerSheets",
                newName: "IX_AnswerSheets_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "AnswerSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnswerSheets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerSheets",
                table: "AnswerSheets",
                column: "AnswerSheet_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheets_RoomId",
                table: "AnswerSheets",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheets_UserId",
                table: "AnswerSheets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheets_AspNetUsers_UserId",
                table: "AnswerSheets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheets_Questions_QuestionId",
                table: "AnswerSheets",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheets_Rooms_RoomId",
                table: "AnswerSheets",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Room_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheets_AspNetUsers_UserId",
                table: "AnswerSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheets_Questions_QuestionId",
                table: "AnswerSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheets_Rooms_RoomId",
                table: "AnswerSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerSheets",
                table: "AnswerSheets");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSheets_RoomId",
                table: "AnswerSheets");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSheets_UserId",
                table: "AnswerSheets");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "AnswerSheets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnswerSheets");

            migrationBuilder.RenameTable(
                name: "AnswerSheets",
                newName: "AnswerSheet");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerSheets_QuestionId",
                table: "AnswerSheet",
                newName: "IX_AnswerSheet_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "StudentAnswerId",
                table: "AnswerSheet",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerSheet",
                table: "AnswerSheet",
                column: "AnswerSheet_Id");

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    Student_Answer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.Student_Answer_Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheet_StudentAnswerId",
                table: "AnswerSheet",
                column: "StudentAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_RoomId",
                table: "StudentAnswers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_UserId",
                table: "StudentAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheet_Questions_QuestionId",
                table: "AnswerSheet",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheet_StudentAnswers_StudentAnswerId",
                table: "AnswerSheet",
                column: "StudentAnswerId",
                principalTable: "StudentAnswers",
                principalColumn: "Student_Answer_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
