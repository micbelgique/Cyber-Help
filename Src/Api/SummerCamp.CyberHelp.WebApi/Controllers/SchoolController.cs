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
    public class SchoolController : BaseController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<School> Get()
        {
            return this.GetFactory().GetSchools();
        }

        // POST api/values
        [HttpPost]
        public long Post([FromBody]School value)
        {
            return this.GetFactory().CreateSchool(value);
        }

        [HttpGet("{schoolId}/alerts")]
        public int AlertsCount(long schoolID)
        {
            return this.GetFactory().GetAlertsForSchool(schoolID);
        }

  
    }
}
