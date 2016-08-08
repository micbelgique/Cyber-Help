using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Mappers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Text;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class AlertsController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var alerts = _factory
                .GetAlerts()
                .OrderByDescending(a => a.RecordedDate)
                .ToList();

            var results = Mapper.Map<List<DataServices.Models.Alert>, List<Models.Alert>>(alerts);

            return View(results);
        }

        public IActionResult Info(long id)
        {
            var alert = _factory
                .GetAlert(id);

            var result = Mapper.Map<DataServices.Models.Alert, Models.Alert>(alert);

            return View(result);
        }

        public IActionResult Validate(long id)
        {
            _factory.ChangeAlertStatus(id, "V");
            return Redirect(Url.Action("Index"));
        }

        public IActionResult OrganizeMeeting(long id)
        {
            _factory.ChangeAlertStatus(id, "I");
            return Redirect(Url.Action("Index"));
        }

        /// <summary>
        /// Generates an iCalendar .ics link and returns it to the user.
        /// </summary>
        /// <param name="downloadFileName">Name of the download file to return.</param>
        /// <param name="evt">The Event.</param>
        /// <returns>The .ics file.</returns>
        public ActionResult createOutlook(long id, string Comment)
        {
            var icalStringbuilder = new StringBuilder();

            icalStringbuilder.AppendLine("BEGIN:VCALENDAR");
            icalStringbuilder.AppendLine("PRODID:-//CyberHelp - Groupe de travail//EN");
            icalStringbuilder.AppendLine("VERSION:2.0");

            icalStringbuilder.AppendLine("BEGIN:VEVENT");
            icalStringbuilder.AppendLine("SUMMARY;LANGUAGE=en-us:" + "Groupe de travail");
            icalStringbuilder.AppendLine("ORGANIZER;CN=\"Voituron Denis / GROUPAV\":mailto:dvoituron@trasysgroup.com");
            icalStringbuilder.AppendLine("ATTENDEE;CN=\"Fiorito Michaël\";RSVP=TRUE:mailto:michael.fiorito@trasysgroup.com");
            icalStringbuilder.AppendLine("CLASS:PUBLIC");
            icalStringbuilder.AppendLine(string.Format("CREATED:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
            icalStringbuilder.AppendLine(String.Format("DESCRIPTION: Atelier de travail sur {0}", Comment));
            icalStringbuilder.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", DateTime.Now.AddDays(1)));
            icalStringbuilder.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", DateTime.Now.AddDays(1)));
            icalStringbuilder.AppendLine("SEQUENCE:0");
            icalStringbuilder.AppendLine("UID:" + Guid.NewGuid());
            icalStringbuilder.AppendLine(
                string.Format(
                    "LOCATION:{0}\\, {1}\\, {2}\\, {3} {4}",
                    "Ville de Mons",
                    "Ville de Mons",
                    "Mons",
                    "",
                    "7000").Trim());
            icalStringbuilder.AppendLine("END:VEVENT");
            icalStringbuilder.AppendLine("END:VCALENDAR");

            var bytes = Encoding.UTF8.GetBytes(icalStringbuilder.ToString());
            _factory.ChangeAlertStatus(id, "I");
            return this.File(bytes, "text/calendar", "alerte.ics");
        }
    }
}
