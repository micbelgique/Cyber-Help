using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.DataServices.Models;
using SummerCamp.CyberHelp.Website.Models;
using AutoMapper;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class ClassroomsController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index(long schoolid = -1)
        {
            List<ClassRoom> items;
            if (schoolid >= 0)
                items = _factory
                    .GetClassRooms()
                    .Where(c => c.SchoolID == schoolid)
                    .OrderBy(c => c.ClassRoomName)
                    .ToList();
            else
                items = _factory
                    .GetClassRooms()
                    .OrderBy(c => c.SchoolName)
                    .ThenBy(c => c.ClassRoomName)
                    .ToList();

            return View(items);
        }

        public IActionResult Info(long id)
        {
            Classroom model = buildModel(id);
            return View(model);
        }

        private Classroom buildModel(long id)
        {
            Classroom newModel = new Classroom();

            var alerts = _factory.GetAlertsForClassRoom(id).OrderBy(c => c.RecordedDate).ToList();
            newModel.Alerts = Mapper.Map<List<Models.Alert>>(alerts);

            newModel.ClassroomInfo = _factory.GetClassRoom(id);
            newModel.Students = _factory.GetStudents().Where(s => s.ClassRoomID == id).ToList();
            newModel.Teacher = newModel.ClassroomInfo.Teacher;

            return newModel;
        }
    }
}
