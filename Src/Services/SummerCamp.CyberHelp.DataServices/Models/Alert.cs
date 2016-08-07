using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.DataServices.Models
{
    public class Alert
    {
        public long CyberAlertID { get; set; }

        public DateTime RecordedDate { get; set; }

        public string CyberAlertType { get; set; }

        public string Comment { get; set; }

        public string Coordinates { get; set; }

        public string StatusCode { get; set; }

        public long CyberHelpUserID { get; set; }

        public string StatusDescription
        {
            get
            {
                switch (StatusCode.ToUpper())
                {
                    case "N":
                        return "Alerte envoyée";
                    case "V":
                        return "Alerte validée";
                    case "I":
                        return "Réunion en cours d'org.";
                    default:
                        return "Code non valide";
                }
            }
        }

    }
}