using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gp_.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorDashboardController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DoctorDashboardController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context; _userManager = userManager;
        }
        [Authorize(Roles = "doctor")]
        public IActionResult Index()
        {
            //var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            ///var doc = _context.doctor.FirstOrDefault((m => m.Id == id));
            //if (doc.isActivated == true)
                return View();
         //   else {
           //     return Redirect("/error");
            //}
        }

        public void getdoc(IFormCollection fr)
        {
           // var val = fr["email"];
            var id = fr["id"];
            var user2 = _userManager.FindByIdAsync(id.ToString());
            RedirectToAction("Index", "UserModels", user2);
            // var user = await _userManager.FindByIdAsync(id);


            // await _userManager.AddToRoleAsync(user2.Result, val.ToString());
            //    if (val.ToString().Equals("patient"))
            //{
            //    await _userManager.AddToRoleAsync(user2.Result, val.ToString());
            //  return RedirectToAction("Create", "UserModels");
            //}
         //   EmailSender e = new EmailSender();
           // await e.SendEmailAsync(val.ToString(), "hey doc see my data", "the user " + HttpContext.User.Identity.Name.ToString() + "wants you to see his/her data , visit myPHR and enter the following code on your dashboard : " + id.ToString());
        }
    }
}