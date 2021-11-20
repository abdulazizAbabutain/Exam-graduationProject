using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.web.Migrations
{
    public partial class add_tabels_UserExamResult_and_RoomExamSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamRoomSessions",
                columns: table => new
                {
                    ExamRoom_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfTries = table.Column<int>(type: "int", nullable: false),
                    UserTries = table.Column<int>(type: "int", nullable: false),
                    MaxTries = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamRoomSessions", x => x.ExamRoom_Id);
                    table.ForeignKey(
                        name: "FK_ExamRoomSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamRoomSessions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExamResults",
                columns: table => new
                {
                    UserExamResult_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExamResults", x => x.UserExamResult_Id);
                    table.ForeignKey(
                        name: "FK_UserExamResults_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExamResults_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamRoomSessions_RoomId",
                table: "ExamRoomSessions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRoomSessions_UserId",
                table: "ExamRoomSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamResults_RoomId",
                table: "UserExamResults",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExamResults_userId",
                table: "UserExamResults",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamRoomSessions");

            migrationBuilder.DropTable(
                name: "UserExamResults");
        }
    }
}
