using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.DataServices.Models
{
    public class ClassRoom
    {
        public long ClassRoomID { get; set; }

        public string ClassRoomName { get; set; }

        public long SchoolID { get; set; }

        public string SchoolName { get; set; }

        public IEnumerable<CyberHelpUser> Students { get; set; }

        public CyberHelpUser Teacher { get; set; }

        public string Description { get; set; }

    }
}
