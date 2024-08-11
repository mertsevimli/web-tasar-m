using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCEgitim.Controllers
{
    
    public class AnasayfaController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
            public IActionResult Hakkimizda()// 1 controller da 1 den fazla action tanımlayabiliiyoruz.
        {
            return View();// Burada View altında Hakkımızzda adında bir view
        }
    public IActionResult Ders12OrnekTasarim()
        {
            return View();
        }
        
    }
}