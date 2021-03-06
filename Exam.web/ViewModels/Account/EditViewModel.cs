using Exam.web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Account
{
    public class EditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not Valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Academic number is required ")]
        [Display(Name = "Academic number")]
        public uint AcadmicNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}
