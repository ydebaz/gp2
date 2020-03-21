using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gp_.Controllers
{
    public class errorController : Controller
    {
        
        [Route("error/{statuscode}")]
        public IActionResult httpstatuscodehandler(int statuscode)
        {
            
            return View();
        }
    }
}