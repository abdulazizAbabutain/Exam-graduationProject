using Exam.web.ViewModels.Account;
using Exam.web.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Room
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public DateTime ExamDateAndTime { get; set; }
        public int DepartmentId { get; set; }
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public List<QuestionsViewModel> Questions { get; set; }


    }
}
