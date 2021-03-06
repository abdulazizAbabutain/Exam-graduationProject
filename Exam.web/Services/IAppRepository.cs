using Exam.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Services
{
    public interface IAppRepository
    {
        //          +----------------------------------------------+
        //          |             room service section             |
        //          +----------------------------------------------+
        List<Room> AllRooms { get; }
        public List<Room> AllRoomsFromUser(string userId);
        void AddRoom(Room room);
        bool RoomExist(int roomid);
        void DeleteRoom(Room room);
        bool JoinRoom(ApplicationUser user, int roomId);
        ApplicationUser GetRoomOwner(int roomId);
        Room GetRoom(int roomId);
        bool IncreseNumberOfTries(int roomId, string userId);
        void RoomUpdate(Room room);

        //          +----------------------------------------------+
        //          |          Question service section            |
        //          +----------------------------------------------+
        void AddQuestion(Questions question);
        List<Questions> GetQuestionsByRoomId(int roomId);
        Questions GetQuestionById(int questionId);
        void DeleteQuestion(Questions question);
        void UpdateQueation(Questions questions);
        //          +----------------------------------------------+
        //          |          User service section            |
        //          +----------------------------------------------+
        public void AddUser(ApplicationUser user);
        public ApplicationUser GetUserById(string userId);
        public ApplicationUser GetUserByUserName(string userName);
        public void UpdateUser(ApplicationUser user);
        public bool UserExist(string userName);
        public bool UserExistById(string userId);
        //          +----------------------------------------------+
        //          |          Answer service section            |
        //          +----------------------------------------------+
        public void AddAnswer(int answer, int roomId, string userId, int queationId, int correctAnswer);
        public List<AnswerSheet> GetAnswerSheet(int roomId, string userId);
        public bool CheckUserTakeTheExam(int roomId, string userName);
        //          +----------------------------------------------+
        //          |          Other service section            |
        //          +----------------------------------------------+
        bool save();

        public void RunPythonScpit();
    }
}
