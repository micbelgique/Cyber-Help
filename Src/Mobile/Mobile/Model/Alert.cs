using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp.CyberHelp.Mobile.Model.WebApi
{

    public class Alert
    {
        public string cyberAlertType { get; set; }
        public string comment { get; set; }
        public string coordinates { get; set; }
        public string statusCode { get; set; }
        public int cyberHelpUserID { get; set; }
        public string statusDescription { get; set; }
        public DateTime recordedDate { get; set; }
    }

}
