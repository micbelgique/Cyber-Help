using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Website.Models
{
    public class Dashboard
    {
        public long NewAlert { get; set; }
        public long ValidateAlert { get; set; }
        public long ClosedAlert { get; set; }
        public long Total { get; set; }

        public List<Alert> LastAlerts { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}
