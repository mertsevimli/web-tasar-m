using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCEgitim.Controllers
{
   
    public class MVC13StringFormatController : Controller
    {
 
        public IActionResult Index()
        {
            ViewBag.MusteriNo = string.Format("M{0:D6}", 18);
            ViewBag.SaticiNo = string.Format("S{0:D6}", 218);
            return View();
        }
    }
}