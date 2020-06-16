using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Data;
using Microsoft.AspNetCore.Authorization;
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
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            var doc = _context.doctor.FirstOrDefault((m => m.Id == id));
            if (doc.isActivated == true)
                return View();
            else
                return View("error");
        }
    }
}