using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Entities
{
    public class AnswerSheet
    {
        [Key]
        [Column("AnswerSheet_Id")]
        public int Id { get; set; }
        [ForeignKey("Question_Id")]
        public int QueastionId { get; set; }
        public Questions Question { get; set; }
        public int Answer { get; set; }
        public int CorrectAnswer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [ForeignKey("User_Id")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
