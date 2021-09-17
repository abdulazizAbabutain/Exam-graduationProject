using Exam.web.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.RoomViewModel
{
    public class CreateRoomViewModel
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public Department Department { get; set; }
        public string RoomOwner { get; set; }
        public IFormFile ExamPaper { get; set; }
    }
}
