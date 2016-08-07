using SummerCamp.CyberHelp.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Website.Models
{
    public class Classroom
    {
        public List<CyberHelpUser> Students { get; set; }
        public List<Alert> Alerts { get; set; }
        public ClassRoom ClassroomInfo { get; set; }
        public CyberHelpUser Teacher { get; set; }
    }
}
