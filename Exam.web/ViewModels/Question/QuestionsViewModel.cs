using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Question
{
    public class QuestionsViewModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int correctAnswer { get; set; }
        public int RoomId { get; set; }
    }
}
