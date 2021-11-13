using Exam.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Room
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Questions> Questions { get; set; }
    }
}
