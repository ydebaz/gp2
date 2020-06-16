using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Data;
using gp_.Models;
using gp_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gp_.Controllers
{
    public class UserRegistrationController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private  ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;

      public UserRegistrationController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        private IUserService _userService;

    //    public UserRegistrationController(IUserService userService)
      //  {
        //    _userService = userService;
        //}


        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userModel);
                //  return RedirectToAction(nameof(Emailconfirmation), new { userModel.Email });
                // return Content($"User {userModel.FirstName}  {userModel.LastName} has been registered successfully");
                return View();
            }
            else
            {
                return View(userModel);
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> userinfo(UserModel um) {
            if (ModelState.IsValid) {
                _context.user.Add(um);
            }
            return View(um);
        }
      
       
        public async Task< IActionResult> Emailconfirmation(string email) {
            ViewBag.Email = email;
            /////
            /*   var user = await _userService.GetUserByEmail(email);
               if (user?.IsEmailConfirmed == true) {
                   return RedirectToAction("index", "openAccount", new { email = email });
                   //                return RedirectToAction("index", "UserDashBoard", new { email = email });*/
            return RedirectToAction("index", "UserDashBoard");



            }
        //user.IsEmailConfirmed = true;
        //          user.EmailConfirmationDate = DateTime.Now;
        //        await _userService.UpdateUser(user);
        ////
        // return View();


        
        public async Task<IActionResult> UpdateUserRole(IFormCollection fr)
        {
            var val = fr["role"];
            var id = fr["id"];
            var user2 = _userManager.GetUserAsync( HttpContext.User);
            // var user = await _userManager.FindByIdAsync(id);


            // await _userManager.AddToRoleAsync(user2.Result, val.ToString());
            if (val.ToString().Equals("patient"))
            {
                await _userManager.AddToRoleAsync(user2.Result, val.ToString());
                return RedirectToAction("Create", "UserModels");
            }
            else
            {
                await _userManager.AddToRoleAsync(user2.Result, val.ToString());

                return RedirectToAction("Create", "DoctorModels");
            }
        }
    }

    public class DisplayViewModel
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersViewModel> Users { get; set; }
    }

    public class UsersViewModel
    {
        public string Email { get; set; }
        public IEnumerable<UsersRole> Roles { get; set; }
    }

    public class UsersRole
    {
        public string Name { get; set; }
    }

    public class RoleViewModel
    {
        public string Name { get; set; }
    }

    public class UpdateUserRoleViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string UserEmail { get; set; }
        public string Role { get; set; }
        public bool Delete { get; set; }
    }
}
   
