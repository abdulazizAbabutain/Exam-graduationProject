using Exam.web.Entities;
using Exam.web.Services;
using Exam.web.ViewModels.RoomViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Exam.web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly UserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RoomController(IRoomRepository roomRepository, UserRepository userRepository, SignInManager<ApplicationUser> signInManager)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }


        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            
            var roomFromRepo = new ListRoomViewModel();
            roomFromRepo.Rooms = _roomRepository.AllRooms;
            return View(roomFromRepo);
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreatRoom()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreatRoom(CreateRoomViewModel model)
        {
            if(ModelState.IsValid)
            {
                var roomOwner = _userRepository.GetUser(model.RoomOwner);
                if(roomOwner == null)
                {
                    throw new ArgumentNullException(nameof(roomOwner));
                }
                var room = new Room
                {
                    RoomId = Guid.NewGuid(),
                    Title = model.Title,
                    Department = model.Department,
                    Description = model.Description,
                    RoomOwner = roomOwner,
                    UserId = roomOwner.Id
                };
                _roomRepository.AddRoom(room);
                _roomRepository.save();
                TempData["Message"] = $"Room {room.RoomId} Created Successfully";
                return RedirectToAction("index", "home");
            }
            return View(model);
        }
        [Authorize]
        public IActionResult ExamRoom(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var roomFromRepo = _roomRepository.GetRoom(id);
            var user = _userRepository.GetUser(User.Identity.Name);
            roomFromRepo.Users.Add(user);
            return View(roomFromRepo);
        }

        public IActionResult DeleteRoom(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var roomFromRepo = _roomRepository.GetRoom(id);
            _roomRepository.DeleteRoom(roomFromRepo);
            _roomRepository.save();
            return RedirectToAction("List", "Room");
        }

        [HttpPost]
        public async Task<IActionResult> SaveRecoredFile()
        {
            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files["video-blob"];
                string UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles");
                string UniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName + ".webm";
                string UploadPath = Path.Combine(UploadFolder, UniqueFileName);
                await file.CopyToAsync(new FileStream(UploadPath, FileMode.Create));
            }
            return Json(HttpStatusCode.OK);
        }


    }
}
