using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.web.Entities
{
    public class Department
    {
        [Key]
        [Column("Department_Id")]
        public int Id { get; set; }
        public string Value { get; set; }

        // static values for lockup table 
        public static Department ComputerScience = new Department { Id = 1, Value = "computer science" };
        public static Department InformationTechnology = new Department { Id = 2, Value = "information technology" };
        public static Department InformationSystem = new Department { Id = 3, Value = "information system" };

    }
}