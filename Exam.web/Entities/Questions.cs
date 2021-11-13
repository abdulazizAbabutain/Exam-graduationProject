using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Entities
{
    public class Questions : CDUDate
    {
        [Key]
        [Column("Question_Id")]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int correctAnswer { get; set; }
        [ForeignKey("Room_Id")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
