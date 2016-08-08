using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.Website.Models;
using SummerCamp.CyberHelp.DataServices.Models;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class AccountController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var schools = _factory.GetSchools().ToList() ;
            return View(schools);
        }

        [HttpPost]
        public IActionResult Index(Login loginModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
