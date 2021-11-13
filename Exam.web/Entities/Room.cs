using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.web.Entities
{
    public class Room : CDUDate
    {
        [Key]
        [Column("Room_Id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public DateTime ExamDateAndTime { get; set; }

        // Relationships for lockup table "Department"
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Application_User_id")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        // filed for Question one 
        public List<Questions> Questions { get; set; } = new List<Questions>();
    }
}