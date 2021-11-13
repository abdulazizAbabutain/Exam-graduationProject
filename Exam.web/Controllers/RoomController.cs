using AutoMapper;
using Exam.web.Entities;
using Exam.web.Services;
using Exam.web.ViewModels.Question;
using Exam.web.ViewModels.Room;
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
        private readonly IAppRepository _AppRepository;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public RoomController(IAppRepository roomRepository,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            _AppRepository = roomRepository ??
                throw new ArgumentNullException(nameof(roomRepository));
            _signInManager = signInManager ??
                throw new ArgumentNullException(nameof(signInManager));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            var roomsFromRepo = _AppRepository.AllRooms;
            var model = new ListRoomViewModel();
            model.Rooms = _mapper.Map<List<RoomViewModel>>(roomsFromRepo);
            return View(model);
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
            if (ModelState.IsValid)
            {
                var userFromRepo = _AppRepository.GetUserByUserName(model.UserName);
                if (userFromRepo == null)
                {
                    return View();

                }
                var roomFromEntity = _mapper.Map<Entities.Room>(model);
                roomFromEntity.ApplicationUserId = userFromRepo.Id;
                _AppRepository.AddRoom(roomFromEntity);
                _AppRepository.save();
                return RedirectToAction("index", "home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ExamRoom(int id, string UserName)
        {

            if (_AppRepository.CheckUserTakeTheExam(id, UserName))
                return RedirectToAction("Index", "Home");
            var roomFromRepo = _AppRepository.GetRoom(id);
            var model = new ExamRoomViewModel();
            model.Room = _mapper.Map<RoomViewModel>(roomFromRepo);
            var listOfQuestion = _AppRepository.GetQuestionsByRoomId(roomFromRepo.Id);
            if (listOfQuestion == null)
            {
                return RedirectToAction("Index", "Home");
            }
            model.Questions = listOfQuestion;
            var answerSheetModel = new List<AnswerSheet>();
            for (int i = 0; i < listOfQuestion.Count; i++)
            {
                answerSheetModel.Add(new AnswerSheet
                {
                    QueastionId = listOfQuestion[i].Id
                });
            }
            model.AnswerSheets = answerSheetModel;

            return View(model);
        }

        [HttpPost]
        public IActionResult ExamRoom(ExamRoomViewModel model)
        {
            var user = _AppRepository.GetUserByUserName(model.UserName);
            foreach (var item in model.AnswerSheets)
            {
                _AppRepository.AddAnswer(
                        answer: item.Answer,
                        roomId: item.RoomId,
                        userId: user.Id,
                        queationId: item.QueastionId,
                        correctAnswer: item.CorrectAnswer
                    );
            }
            _AppRepository.save();
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// soft delete the room 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteRoom(int id)
        {
            var roomFromRepo = _AppRepository.GetRoom(id);
            if (roomFromRepo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            _AppRepository.DeleteRoom(roomFromRepo);
            _AppRepository.save();
            var userFromRepo = _AppRepository.GetUserById(roomFromRepo.ApplicationUserId);
            return RedirectToAction("RoomList", "Account", new { UserName = userFromRepo.UserName });
        }


        [HttpGet]
        public IActionResult RoomDetails(int id)
        {
            var roomFromRepo = _AppRepository.GetRoom(id);

            var model = _mapper.Map<RoomDetailsViewModel>(roomFromRepo);

            model.User = _AppRepository.GetUserById(roomFromRepo.ApplicationUserId);
            var questions = _AppRepository.GetQuestionsByRoomId(id);
            model.Questions = questions;
            return View(model);
        }
        [HttpGet]
        public IActionResult RoomEdit(int id)
        {
            var roomFromrepo = _AppRepository.GetRoom(id);
            var model = _mapper.Map<EditRoomViewModel>(roomFromrepo);
            return View(model);
        }
        [HttpPost]
        public IActionResult RoomEdit(EditRoomViewModel model)
        {
            var roomFromEntity = _mapper.Map<Room>(model);
            _AppRepository.RoomUpdate(roomFromEntity);
            _AppRepository.save();
            return RedirectToAction("List", "Room");
        }
        [HttpGet]
        public IActionResult ShowResult(int id, string UserName)
        {
            var model = new ShowReultsViewModel();
            var userFromRepo = _AppRepository.GetUserByUserName(UserName);
            model.AnswerSheets = _AppRepository.GetAnswerSheet(id, userFromRepo.Id);
            foreach (var answer in model.AnswerSheets)
            {
                answer.Question = _AppRepository.GetQuestionById(answer.QueastionId);
            }
            return View(model);
        }
    }
}
