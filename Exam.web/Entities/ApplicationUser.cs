using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Department Departments { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
