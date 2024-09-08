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
   
    public class MVC16HttpContextController : Controller
    {
        public IActionResult Index()
        {
            var geriDonusAdresi = HttpContext.Request.Query["ReturnUrl"];//* : burada adres çubuğundaki ReturnUrl isimliQueryString nesnesini yakalayıp işleyebiliriyoruz.Kullanıcıyı buraada yer alan ekrana yönlendirmek için mesela
            var urunAdi = MVC16HttpContextController.Request.Query["UrunAdi"];//* Bu şekilde adres cubuğundan gönderilen ürün adını yakalayıp veritabanına eşleşen kayıtları bulup kullanıcıya ilgili ürünleri sunabiliriz.
            return View();
        }

       
     
    }
}