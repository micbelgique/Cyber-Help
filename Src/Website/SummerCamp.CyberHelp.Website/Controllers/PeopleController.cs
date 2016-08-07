using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.DataServices.Models;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class PeopleController : BaseController
    {

        public IActionResult Students(long Id = -1, bool filterBySchool = false)
        {
            List<CyberHelpUser> students;
            if (Id >= 0)
                if (filterBySchool)
                    students = _factory
                        .GetStudents()
                        .Where(s => s.SchoolID == Id)
                        .OrderBy(s => s.FirstName)
                        .ToList();
                else
                    students = _factory
                        .GetStudents()
                        .Where(s => s.ClassRoomID == Id)
                        .OrderBy(s => s.FirstName)
                        .ToList();
            else
                students = _factory
                    .GetStudents()
                    .OrderBy(s => s.FirstName)
                    .ToList();
            return View(students);
        }

        public IActionResult Teachers(long Id = -1, bool filterBySchool = false)
        {
            List<CyberHelpUser> students;
            if (Id >= 0)
                if (filterBySchool)
                    students = _factory
                        .GetTeachers()
                        .Where(s => s.SchoolID == Id)
                        .OrderBy(s => s.FirstName).ToList();
                else
                    students = _factory
                        .GetTeachers()
                        .Where(s => s.ClassRoomID == Id)
                        .OrderBy(s => s.FirstName)
                        .ToList();
            else
                students = _factory
                    .GetTeachers()
                    .OrderBy(s => s.FirstName)
                    .ToList();
            return View(students);
        }
    }
}
