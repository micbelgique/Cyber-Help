using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
