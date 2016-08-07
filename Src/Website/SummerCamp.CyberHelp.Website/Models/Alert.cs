using SummerCamp.CyberHelp.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Website.Models
{
    public class Alert
    {
        public long CyberAlertID { get; set; }

        public DateTime RecordedDate { get; set; }

        public string CyberAlertType { get; set; }

        public string Comment { get; set; }

        public string Coordinates { get; set; }

        public string StatusCode { get; set; }

        public long CyberHelperUserID { get; set; }

        public string StatusDescription
        {
            get
            {
                switch (StatusCode.ToUpper())
                {
                    case "N": return "Alerte envoyée";
                    case "V": return "Alerte validée";
                    case "I": return "Alerte en cours d'organisation";
                    default: return "Statut invalide";
                }
            }

        }

        public bool CanValidate
        {
            get
            {
                return StatusCode == "N"; 
            }
        }

        public bool CanOrganizeMeeting
        {
            get
            {
                return StatusCode == "V";
            }
        }

        public string StatusColorClass
        {
            get
            {
                switch (StatusCode)
                {
                    case "N":
                        return "bgm-red";
                    case "V":
                        return "bgm-cyan";
                    case "I":
                        return "bgm-green";
                    default:
                        return "bgm-gray";
                }
            }
        }

        public string StatusLineClass
        {
            get
            {
                switch (StatusCode)
                {
                    case "N":
                        return "danger c-white";
                    case "V":
                        return "warning c-white";
                    case "I":
                        return "success c-white";
                    default:
                        return "info";
                }
            }
        }
    }
}
