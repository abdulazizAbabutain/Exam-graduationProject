using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.web.Entities
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Department Department { get; set; }
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public ApplicationUser RoomOwner { get; set; }
        public string UserId { get; set; }
        public ExamFile ExamPaper { get; set; }
    }
}