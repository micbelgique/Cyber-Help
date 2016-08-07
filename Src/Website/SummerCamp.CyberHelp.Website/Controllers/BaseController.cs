using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SummerCamp.CyberHelp.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Website.Controllers
{
    public class BaseController : Controller
    {
        protected Factory _factory;

        public BaseController()
        {
            _factory = new Factory();

        }
    }
}
