using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCEgitim.Models; //* UyeContext namespace
using MVCEgitim.Extensions;  //* Bunuda manuel olarak ekledik.


namespace MVCEgitim.Controllers
{
    public class MVC12SessionController : Controller
    {
        private readonly UyeContext _context;

        public MVC12SessionController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Uyeler.FirstOrDefault(u =>
                u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre
            );
            if (kullanici != null)
            {
                HttpContext.Session.SetString("kullanici", kullaniciAdi);//* sessionda Setstring metoduyla string tipinde veri saklayabiliriz.
                HttpContext.Session.SetString("sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1);//* Sessionda SetInt32 metoduyla int tipinde veri saklayabiliriz.
                HttpContext.Session.SetString("userguid", Guid.NewGuid().ToString());
                HttpContext.Session.SetJson("uye", kullanici);//* Kendi yazdığımız set Json metoduna çektiğimiz kullanıcıyı json olarak yükle


                return RedirectToAction("SessionOku"); //* işlem başarılıysa SessionOku sayfasına git
            }
            else
            {
                TempData["Mesaj"] = @"<div class ='alert alert-danger'> Giriş Başarısız  </div>";
            }
            return View("Index");
        }

        public IActionResult SessionOku()
        {
            return View();
        }
        [HttpPost]
         public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("userguid");//* userguid isimli session ı sil
             HttpContext.Session.Clear();//* Tüm sessionları sil
             return RedirectToAction("Index");
        }
    }
}
