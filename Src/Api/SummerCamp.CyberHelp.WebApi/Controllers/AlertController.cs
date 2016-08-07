using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.DataServices.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SummerCamp.CyberHelp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AlertController : BaseController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Alert> Get()
        {
            return this.GetFactory().GetAlerts();
        }

        [HttpGet("{id}/validate")]
        public void Validate(int id)
        {
            this.GetFactory().ChangeAlertStatus(id, "V");
        }

        [HttpGet("{id}/organizeStarted")]
        public void OrganizeStarted(int id)
        {
            this.GetFactory().ChangeAlertStatus(id, "I");
        }

        // POST api/values
        [HttpPost]
        public long Post([FromBody]Alert value)
        {
            long id =  this.GetFactory().CreateAlert(value);
            return id;
        }

    }
}
