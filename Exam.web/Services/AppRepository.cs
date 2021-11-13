using Exam.web.DBcontexts;
using Exam.web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Services
{
    public class AppRepository : IAppRepository
    {
        private readonly ExamAppContext _appContext;

        public AppRepository(ExamAppContext appContext)
        {
            _appContext = appContext
                ?? throw new ArgumentNullException(nameof(appContext));
        }

        public List<Room> AllRooms
        {
            get
            {
                return _appContext.Rooms
                    .Where(a => a.IsDeleted == false)
                    .Include(a => a.ApplicationUser)
                    .OrderBy(a => a.CreateDate)
                    .ToList();
            }
        }
        public List<Room> AllRoomsFromUser(string userId)
        {
            return _appContext.Rooms
                .Where(a => a.ApplicationUserId == userId && a.IsDeleted == false)
                .OrderBy(a => a.CreateDate)
                .ToList();
        }
        public void AddRoom(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));
            room.CreateDate = DateTime.UtcNow;
            _appContext.Rooms.Add(room);
        }
        public bool RoomExist(int roomid)
        {
            return _appContext.Rooms.Any(a => a.Id == roomid);
        }
        public void DeleteRoom(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));
            room.IsDeleted = true;
            _appContext.Rooms.Update(room);

            // hard delete
            // _appContext.Rooms.Remove(room);
        }
        public bool JoinRoom(ApplicationUser user, int roomId)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (!RoomExist(roomId))
                return false;
            var roomFromContext = GetRoom(roomId);
            // roomFromContext.Users.Add(user);
            return true;
        }
        public ApplicationUser GetRoomOwner(int roomId)
        {
            var roomFromContext = GetRoom(roomId);
            if (roomFromContext == null)
                throw new ArgumentNullException(nameof(roomFromContext));
            var roomOwner = roomFromContext.ApplicationUser;
            return roomOwner;
        }
        /// <summary>
        /// Get the Room object from the Database.
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>the object from class Room if found, otherwise the return will be null.</returns>
        public Room GetRoom(int roomId)
        {
            return _appContext.Rooms
                .Where(a => a.IsDeleted == false)
                .FirstOrDefault(a => a.Id == roomId);
        }
        public void RoomUpdate(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            var roomFromDB = GetRoom(room.Id);
            roomFromDB.Title = room.Title;
            roomFromDB.Description = room.Description;
            roomFromDB.DepartmentId = room.DepartmentId;
            roomFromDB.Class = room.Class;
            roomFromDB.ExamDateAndTime = room.ExamDateAndTime;
            roomFromDB.Subject = room.Subject;

        }
        /// <summary>
        /// get the user via user-ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>return the applicationUser Object otherwise will return null.</returns>
        public ApplicationUser GetUserById(string userId)
        {
            return _appContext.ApplicationUsers
                .Where(a => a.IsDeleted == false)
                .FirstOrDefault(a => a.Id == userId.ToString());
        }
        /// <summary>
        /// get the user via the user-name. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>return the object if applicationUser if found, otherwise return null</returns>
        public ApplicationUser GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName));

            return _appContext.ApplicationUsers
                .Where(a => a.IsDeleted == false)
                .FirstOrDefault(a => a.UserName == userName);
        }
        public bool UserExist(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName));
            return _appContext.ApplicationUsers
                .Where(a => a.IsDeleted == false)
                .Any(a => a.UserName == userName);
        }
        /// <summary>
        /// save all the changes that happened in the context to the database
        /// </summary>
        /// <returns>true if were any changes, otherwise false</returns>
        public bool save()
        {
            return (_appContext.SaveChanges() >= 0);
        }
        // will be added in the register via using auto mapper 
        public void AddUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var userFromDB = GetUserById(user.Id);
            if (userFromDB == null)
                throw new ArgumentNullException(nameof(userFromDB));

            userFromDB.FirstName = user.FirstName;
            userFromDB.LastName = user.LastName;
            userFromDB.Email = user.Email;
            userFromDB.Gender = user.Gender;
            userFromDB.DepartmentId = user.DepartmentId;
            userFromDB.UpdateDate = DateTime.UtcNow;

            _appContext.Update(userFromDB);
        }
        //          +----------------------------------------------+
        //          |          Question service section            |
        //          +----------------------------------------------+
        public void AddQuestion(Questions question)
        {
            _appContext.Questions.Add(question);
        }
        public List<Questions> GetQuestionsByRoomId(int roomId)
        {
            return _appContext.Questions
                .Where(a => a.IsDeleted == false && a.RoomId == roomId)
                .ToList();
        }
        public Questions GetQuestionById(int questionId)
        {
            return _appContext.Questions
                .Where(a => a.IsDeleted == false && a.Id == questionId)
                .FirstOrDefault();
        }
        public void DeleteQuestion(Questions question)
        {
            question.IsDeleted = true;
            _appContext.Questions.Update(question);
        }
        public void UpdateQueation(Questions questions)
        {
            if (questions == null)
                throw new ArgumentNullException(nameof(questions));

            var questionsFromDB = GetQuestionById(questions.Id);

            questionsFromDB.Question = questions.Question;
            questionsFromDB.Option1 = questions.Option1;
            questionsFromDB.Option2 = questions.Option2;
            questionsFromDB.Option3 = questions.Option3;
            questionsFromDB.Option4 = questions.Option4;
            questionsFromDB.correctAnswer = questions.correctAnswer;
            questionsFromDB.UpdateDate = DateTime.UtcNow;
            _appContext.Questions.Update(questionsFromDB);

        }
        public void AddAnswer(int answer, int roomId, string userId, int queationId, int correctAnswer)
        {
            var answerSheet = new AnswerSheet
            {
                Answer = answer,
                RoomId = roomId,
                UserId = userId,
                QueastionId = queationId,
                CorrectAnswer = correctAnswer

            };
            _appContext.AnswerSheets.Add(answerSheet);
        }

        public List<AnswerSheet> GetAnswerSheet(int roomId, string userId)
        {
            return _appContext.AnswerSheets
                .Where(a => a.RoomId == roomId && a.UserId == userId)
                .ToList();
        }

        public bool CheckUserTakeTheExam(int roomId, string userName)
        {
            var userFromDB = GetUserByUserName(userName);
            if (userFromDB == null)
                throw new ArgumentNullException(nameof(userFromDB));

            return _appContext.AnswerSheets
                .Where(a => a.UserId == userFromDB.Id && a.RoomId == roomId)
                .Any();
        }
    }
}
