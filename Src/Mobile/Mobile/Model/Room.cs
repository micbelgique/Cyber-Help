using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp.CyberHelp.Mobile.Model
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
