using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Question
{
    public class CreateQueationViewModel
    {
        [Required(ErrorMessage = "Question is required")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Option1 is required")]
        [Display(Name = "Option 1")]
        public string Option1 { get; set; }
        [Required(ErrorMessage = "Option2 is required")]
        [Display(Name = "Option 2")]
        public string Option2 { get; set; }
        [Required(ErrorMessage = "Option3 is required")]
        [Display(Name = "Option 3")]
        public string Option3 { get; set; }
        [Required(ErrorMessage = "Option4 is required")]
        [Display(Name = "Option 4")]
        public string Option4 { get; set; }
        [Required(ErrorMessage = "CorrectAnswer is required")]
        [Display(Name = "Correct Answer")]
        public int CorrectAnswer { get; set; }
        public int RoomId { get; set; }
    }
}
