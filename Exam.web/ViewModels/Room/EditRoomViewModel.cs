using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Room
{
    public class EditRoomViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [MaxLength(1500, ErrorMessage = "the Description can not be longer than 500 character")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "class is required")]
        [MaxLength(50, ErrorMessage = "class can not be more than 50 characters")]
        public string Class { get; set; }
        [Required(ErrorMessage = "Exam date is required")]
        public DateTime ExamDateAndTime { get; set; }
        [Required(ErrorMessage = "Exam time is required")]
        public string Subject { get; set; }
    }
}
