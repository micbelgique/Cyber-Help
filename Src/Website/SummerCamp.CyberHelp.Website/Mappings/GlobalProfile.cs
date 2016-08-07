using AutoMapper;
using SummerCamp.CyberHelp.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Website.Mappings
{
    public class GlobalProfile : Profile
    {
        public GlobalProfile()
        {
            MapAlerts();
        }

        public void MapAlerts()
        {
            CreateMap<DataServices.Models.Alert, Alert>();
        }

    }
}
