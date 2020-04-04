using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Models;
using gp_.Services;
using Microsoft.AspNetCore.Mvc;

namespace gp_.Controllers
{
    public class UserRegistrationController : Controller
    {


        private IUserService _userService;

        public UserRegistrationController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userModel);
                return RedirectToAction(nameof(Emailconfirmation), new { userModel.Email });
                // return Content($"User {userModel.FirstName}  {userModel.LastName} has been registered successfully");
            }
            else
            {
                return View(userModel);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Emailconfirmation(string email) {
            ViewBag.Email = email;
            /////
            var user = await _userService.GetUserByEmail(email);
            if (user?.IsEmailConfirmed == true) {
                return RedirectToAction("index", "openAccount", new { email = email });
                //                return RedirectToAction("index", "UserDashBoard", new { email = email });
                

            }
//user.IsEmailConfirmed = true;
  //          user.EmailConfirmationDate = DateTime.Now;
    //        await _userService.UpdateUser(user);
            ////
            return View();
        }
    }
}