using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Entities
{
    public class UserExamResult
    {
        [Key]
        [Column("UserExamResult_Id")]
        public int Id { get; set; }
        public int TotalPoints { get; set; }
        // foreign keys - relationship table
        [ForeignKey("Room_I")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [ForeignKey("User_Id")]
        public string userId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
