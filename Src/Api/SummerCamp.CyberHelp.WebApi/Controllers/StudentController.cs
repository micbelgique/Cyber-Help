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
    public class StudentController : BaseController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<CyberHelpUser> Get()
        {
            return this.GetFactory().GetStudents();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
    }
}
