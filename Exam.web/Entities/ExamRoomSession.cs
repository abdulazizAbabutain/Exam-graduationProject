using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Entities
{
    public class ExamRoomSession
    {
        [Key]
        [Column("ExamRoom_Id")]
        public int Id { get; set; }
        [DefaultValue(2)]
        public int NumberOfTries { get; set; }
        public int UserTries { get; set; }
        [DefaultValue(5)]
        public int MaxTries { get; set; }
        public DateTime UserEntedDate { get; set; }
        public DateTime UserExitDate { get; set; }
        // Foreign Keys
        [ForeignKey("User_Id")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Room_Id")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
