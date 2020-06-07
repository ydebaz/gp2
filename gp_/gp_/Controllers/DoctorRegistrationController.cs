using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Services;
using Microsoft.AspNetCore.Mvc;
using gp_.Models;

namespace gp_.Controllers
{
    public class DoctorRegistrationController : Controller
    {

        private IDoctorService _docService;

        public DoctorRegistrationController(IDoctorService docService)
        {
            _docService = docService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Index(DoctorModel docModel)
        {
            if (ModelState.IsValid)
            {
              //  await _docService.RegisterDoc(docModel);
                //   return RedirectToAction(nameof(Emailconfirmation), new { docModel.Email });
                return View();
                // return Content($"User {userModel.FirstName}  {userModel.LastName} has been registered successfully");
            }
            else
            {
                return View(docModel);
            }
        }
/*
        [HttpGet]
        public IActionResult Emailconfirmation(string email)
        {
            ViewBag.Email = email;
            return View();
        }*/
    }
}