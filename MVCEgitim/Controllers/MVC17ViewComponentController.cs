using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCEgitim.Models;

namespace MVCEgitim.Controllers
{
    
    public class MVC17ViewComponentController : Controller
    {
       private readonly UyeContext _context;

       public MVC17ViewComponentController(UyeContext context)
       {
        _context = context;
       }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}