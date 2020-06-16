using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Data;
using gp_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gp_.Controllers
{
    [Authorize(Roles = "patient")]
    public class UserDashboardController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;

        public UserDashboardController(
              ApplicationDbContext context,
              UserManager<IdentityUser> userManager,
              RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       public async void senddoc(IFormCollection fr)
        {
            var val = fr["email"];
            var id = fr["id"];
            var user2 = _userManager.GetUserAsync(HttpContext.User);
            // var user = await _userManager.FindByIdAsync(id);


            // await _userManager.AddToRoleAsync(user2.Result, val.ToString());
            //    if (val.ToString().Equals("patient"))
            //{
            //    await _userManager.AddToRoleAsync(user2.Result, val.ToString());
            //  return RedirectToAction("Create", "UserModels");
            //}
            EmailSender e = new EmailSender();
          await  e.SendEmailAsync(val.ToString(), "hey doc see my data", "the user "+ HttpContext.User.Identity.Name.ToString()+"wants you to see his/her data , visit myPHR and enter the following code on your dashboard : "+id.ToString());
        }
    }
}
