using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Website.Mappings
{
    public static class Configuration
    {
        public static void Configure()
        {
            var config = new MapperConfigurationExpression();
            config.AddProfile<GlobalProfile>();

            Mapper.Initialize(config);
        }
    }
}
