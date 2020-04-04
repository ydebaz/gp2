using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gp_.Models;
using gp_.Services;
namespace gp_.Controllers
{
    public class openAccountController : Controller
    {
        private IUserService _userService;

        public openAccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task< IActionResult> Index(string mail)
        {
            var openAccountModel = new openAccountModel { usermail=mail};
            return View(openAccountModel);
        }
    }
}