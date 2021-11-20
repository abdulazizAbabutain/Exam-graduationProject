using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.CustomValidationAttribute
{
    /*
     * 
     *      this class is from answer in stackoverFlow by Xueli Chen
     *      
     *      you can find the original answer via the link below 
     *      https://stackoverflow.com/questions/56588900/how-to-validate-uploaded-file-in-asp-net-core
     *
     */
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage(extension));
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string extension)
        {
            return $"The file you upload ends with {extension} it should be ending with .png or .jpg";
        }
    }
}
