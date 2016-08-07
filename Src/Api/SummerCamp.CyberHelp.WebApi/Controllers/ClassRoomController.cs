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
    public class ClassRoomController : BaseController
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<ClassRoom> Get()
        {
            return this.GetFactory().GetClassRooms();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ClassRoom Get(int id)
        {
            return this.GetFactory().GetClassRoom(id);

        }
        // POST api/values
        [HttpPost]
        public long Post([FromBody]ClassRoom value)
        {
            return this.GetFactory().CreateClassRoom(value);
        }

        [HttpGet("{classroomID}/alerts")]
        public int AlertsCount(long classRoomID)
        {
            return this.GetFactory().GetAlertsCountForClassRoom(classRoomID);
        }


    }
}
