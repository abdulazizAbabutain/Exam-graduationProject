using Exam.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Services
{
    public interface IRoomRepository
    {
        IEnumerable<Room> AllRooms { get; }
        void AddRoom(Room room);
        bool RoomExist(Guid roomid);
        void DeleteRoom(Room room);
        bool JoinRoom(ApplicationUser user, Guid roomId);
        ApplicationUser GetRoomOwner(Guid roomId);
        Room GetRoom(Guid roomId);
        bool save();
    }
}
