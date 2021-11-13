using AutoMapper;
using Exam.web.Entities;
using Exam.web.ViewModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomViewModel, Room>();
            CreateMap<Room, RoomDetailsViewModel>();
            CreateMap<Room, EditRoomViewModel>();
            CreateMap<EditRoomViewModel, Room>();

            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();


        }
    }
}
