using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCEgitim.Models; // Models klasöründeki classları kullanabilmek için bu satırı gerekli!!! Modelste açtığın şeyin namespace i buraya yapıştır.

namespace MVCEgitim.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YeniUye()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniUye(Uye uye)
        {
            if(ModelState.IsValid)// Eğer Model validasyon kurallarına uyulmuşsa,tersi için !ModelState.IsValid
            {
                // budada gelen uye nesnesini veritabanına kaydedebiliriz.
            }
            else{
                ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz!");
            }
            return View(uye);
        }
    }
}
