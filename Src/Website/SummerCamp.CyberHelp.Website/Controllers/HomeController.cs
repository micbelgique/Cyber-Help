using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.Website.Models;
using AutoMapper;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var dashboardModel = buildDashboardModel();
            return View(dashboardModel);
        }

        private Dashboard buildDashboardModel()
        {
            var result = new Dashboard();
            DefineCount(result);
            return result;
        }

        private void DefineCount(Dashboard model)
        {
            var alerts = _factory.GetAlerts().ToList();
            model.ClosedAlert = alerts.Where(a => a.StatusCode == "I").Count();
            model.NewAlert = alerts.Where(a => a.StatusCode == "N").Count();
            model.ValidateAlert = alerts.Where(a => a.StatusCode == "V").Count();
            model.Total = alerts.Count();
            model.Alerts = Mapper.Map<List<DataServices.Models.Alert>, List<Models.Alert>>(alerts);
            model.LastAlerts = model.Alerts.OrderByDescending(a => a.RecordedDate).Take(5).ToList();

        }
    }
}
