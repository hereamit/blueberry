﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueberryPro.Controllers
{
    public class CoachingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
