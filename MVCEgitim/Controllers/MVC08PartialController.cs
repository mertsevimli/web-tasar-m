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
    public class MVC08PartialController : Controller
    {
        private readonly UyeContext _context;

        public MVC08PartialController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Uyeler.FirstOrDefault()); // _Context üzerindeki uyeler tablosunda bulduğun ilk kaydı ekrana yolla
        }
    }
}
