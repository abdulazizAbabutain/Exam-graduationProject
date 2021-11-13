using AutoMapper;
using Exam.web.Services;
using Exam.web.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IAppRepository _AppRepository;
        private readonly IMapper _mapper;

        public QuestionController(IAppRepository roomRepository,
            IMapper mapper)
        {
            _AppRepository = roomRepository ??
                throw new ArgumentNullException(nameof(roomRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult AddQuestion(int id)
        {
            var model = new CreateQueationViewModel();
            model.RoomId = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult AddQuestion(CreateQueationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var questionFromEntity = _mapper.Map<Entities.Questions>(model);
            _AppRepository.AddQuestion(questionFromEntity);
            _AppRepository.save();
            return RedirectToAction("RoomDetails", "Room", new { id = questionFromEntity.RoomId });
        }
        public IActionResult DeleteQuestion(int id)
        {
            var questionFromRepo = _AppRepository.GetQuestionById(id);
            _AppRepository.DeleteQuestion(questionFromRepo);
            _AppRepository.save();
            return RedirectToAction("RoomDetails", "Room", new { id = questionFromRepo.RoomId });
        }
        [HttpGet]
        public IActionResult EditQuestion(int id)
        {
            var questionsFromRepo = _AppRepository.GetQuestionById(id);
            var model = _mapper.Map<EditquestionViewModel>(questionsFromRepo);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditQuestion(EditquestionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var questionFromentity = _mapper.Map<Entities.Questions>(model);
            _AppRepository.UpdateQueation(questionFromentity);
            _AppRepository.save();
            return RedirectToAction("RoomDetails", "Room", new { id = model.RoomId });
        }

    }
}
