using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.DataServices.Models
{
    public class CyberHelpUser
    {
        public long CyberHelpUserID { get; set; }

        public string Login { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public long ClassRoomID { get; set; }

        public string ClassRoomName { get; set; }

        public int CyberHelpYear { get; set; }

        public string SchoolName { get; set; }

        public long SchoolID { get; set; }
    }
}
