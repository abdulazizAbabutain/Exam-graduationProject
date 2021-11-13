using Exam.web.Entities;
using Exam.web.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.ViewModels.Room
{
    public class ExamRoomViewModel
    {

        public RoomViewModel Room { get; set; }
        public List<Questions> Questions { get; set; }
        public List<AnswerSheet> AnswerSheets { get; set; }
        public string UserName { get; set; }

    }
}
