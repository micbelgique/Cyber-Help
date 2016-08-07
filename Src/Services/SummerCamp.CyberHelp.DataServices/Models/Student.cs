using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.DataServices.Models
{
    public class Student
    {
        public long StudentID { get; set; }

        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long ClassRoomID { get; set; }

        public int CyberHelpYear { get; set; }
    }
}
