using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp.CyberHelp.Mobile.Model
{
    public class StatusItem
    {
        public string CreatedDateFormatted { get; set; }

        public string Description { get; set; }

        public StatusItemState State { get; set; }

        public string StateFormatted { get
            {
                switch (this.State)
                {
                    case StatusItemState.New:
                        return "Envoyée";
                    case StatusItemState.InProgress:
                        return "En cours d'organisation";
                    case StatusItemState.Validated:
                        return "Validée";
                    default:
                        return string.Empty;
                }
            }
        }

        public string StateColor
        {
            get
            {
                switch (this.State)
                {
                    case StatusItemState.New:
                        return "#ff7f0000";                 // Red
                    case StatusItemState.InProgress:
                        return "#ffff6A00";                 // Orange
                    case StatusItemState.Validated:
                        return "#ff267f00";                 // Green
                    default:
                        return "#ff000000";
                }
            }
        }
    }

    public enum StatusItemState
    {
        New,
        InProgress,
        Validated
    }
}
