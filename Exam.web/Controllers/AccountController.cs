using AutoMapper;
using Exam.web.Entities;
using Exam.web.Services;
using Exam.web.ViewModels;
using Exam.web.ViewModels.Account;
using Exam.web.ViewModels.Room;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAppRepository appRepository,
            IMapper mapper)
        {
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ??
                throw new ArgumentNullException(nameof(signInManager));
            _appRepository = appRepository ??
                throw new ArgumentNullException(nameof(appRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AcadmicNumber = model.AcadmicNumber,
                    Gender = model.Gender,
                    DepartmentId = model.DepartmentId,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                // if the user send Invalid data such as user-name doesn't exist in the database it will display the error massage 
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public IActionResult Edit(string UserName)
        {

            var userFromRepo = _appRepository.GetUserByUserName(UserName);
            var model = new EditViewModel()
            {
                Id = userFromRepo.Id,
                UserName = userFromRepo.UserName,
                FirstName = userFromRepo.FirstName,
                LastName = userFromRepo.LastName,
                Email = userFromRepo.Email,
                AcadmicNumber = userFromRepo.AcadmicNumber,
                Gender = userFromRepo.Gender,
                DepartmentId = userFromRepo.DepartmentId

            };
            return View(model);
        }

        [HttpPost]
        // make service for update the user account 
        public IActionResult Edit(EditViewModel model)
        {
            var user = _appRepository.GetUserByUserName(model.UserName);
            // will be added after making the auto mapper
            // _appRepository.UpdateUser();
            return View();
        }
        [HttpGet]
        public IActionResult RoomList(string UserName)
        {
            var userFromRepo = _appRepository.GetUserByUserName(UserName);
            var roomsFromRepo = _appRepository.AllRoomsFromUser(userFromRepo.Id);
            var model = new ListRoomViewModel();
            model.Rooms = _mapper.Map<List<RoomViewModel>>(roomsFromRepo);
            return View(model);
        }
    }
}
