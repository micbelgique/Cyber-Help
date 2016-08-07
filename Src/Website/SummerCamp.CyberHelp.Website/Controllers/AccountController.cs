using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.Website.Models;
using SummerCamp.CyberHelp.DataServices.Models;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //var schools = _factory.GetSchools();
            var schools = new List<School>()
            {
                new School() {SchoolID = 1, SchoolName = "Athenee Royal de Mons" },
                new School() {SchoolID = 2, SchoolName = "Université de Mons" },
                new School() {SchoolID = 2, SchoolName = "Ecole alternative de Mons" }
            };
            return View(schools);
        }

        [HttpPost]
        public IActionResult Index(Login loginModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
