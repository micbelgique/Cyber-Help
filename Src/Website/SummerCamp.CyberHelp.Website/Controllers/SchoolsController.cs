using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class SchoolsController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var items = _factory
                .GetSchools()
                .OrderBy(a => a.SchoolName);

            return View(items);
        }
    }
}
