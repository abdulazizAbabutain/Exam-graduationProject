using Exam.web.CustomValidationAttribute;
using Exam.web.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Account
{
    public class RegisterViewModel
    {
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
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Conform Password")]
        [Compare("Password", ErrorMessage = "the password are not matched")]
        public string ConformPassword { get; set; }
        [Display(Name = "Academic number")]
        [Required(ErrorMessage = "Academic number is required")]
        public uint AcadmicNumber { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "the file is required, please select a file")]
        [DataType(DataType.Upload)]
        // custom attribute from CustomValidationAttribute
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Photo { get; set; }
    }
}
