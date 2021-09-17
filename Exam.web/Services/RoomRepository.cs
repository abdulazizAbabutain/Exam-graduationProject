using Exam.web.DBcontexts;
using Exam.web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ExamAppContext _appContext;

        public RoomRepository(ExamAppContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public IEnumerable<Room> AllRooms
        {
            get
            {
                return _appContext.Rooms.Include(a => a.RoomOwner).OrderBy(a => a.Title);
            }
        }

        public void AddRoom(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));
            _appContext.Rooms.Add(room);
         
        }
        public bool RoomExist(Guid roomid)
        {
            if (roomid == Guid.Empty)
                throw new ArgumentNullException(nameof(roomid));
            return _appContext.Rooms.Any(a => a.RoomId == roomid);
        }
        public void DeleteRoom(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            _appContext.Rooms.Remove(room);
           
        }
        public bool JoinRoom(ApplicationUser user, Guid roomId)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (roomId == Guid.Empty)
                throw new ArgumentNullException(nameof(roomId));
            if (!RoomExist(roomId))
                return false;

            var roomFromContext = GetRoom(roomId);
            roomFromContext.Users.Add(user);
            return true; 
            

        }
        public ApplicationUser GetRoomOwner(Guid roomId)
        {
            if (roomId == Guid.Empty)
                throw new ArgumentNullException(nameof(roomId));
            var roomFromContext = GetRoom(roomId);
            if (roomFromContext == null)
                throw new ArgumentNullException(nameof(roomFromContext));
            var roomOwner = roomFromContext.RoomOwner;

            return roomOwner; 

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>return Room object</returns>
        public Room GetRoom(Guid roomId)
        {
            if (Guid.Empty == roomId)
                throw new ArgumentNullException(nameof(roomId));
            return _appContext.Rooms.FirstOrDefault(a => a.RoomId == roomId);
        }
        /// <summary>
        /// save the context into the database  
        /// </summary>
        /// <returns>True if were changes in the Database otherwise false</returns>
        public bool save()
        {
            return (_appContext.SaveChanges() >= 0); 
        }

    }
}
