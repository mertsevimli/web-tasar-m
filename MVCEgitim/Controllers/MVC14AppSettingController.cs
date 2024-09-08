using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCEgitim.Controllers
{
    public class MVC14AppSettingController : Controller
    {
     
     private readonly IConfiguration _configuration;// appsettings.json dosyasına erişebilmek için gerekli nesne
     public MVC14AppSettingController(IConfiguration configuration)
     {
        _configuration = configuration;// yukarıdaki boş nesne burada dolduruluyor
     }
        public IActionResult Index()
        {
            ViewBag.MailinGidecegiAdres = _configuration["Email"];
            ViewBag.MailSunucu = _configuration["MailSunucu"];
            ViewBag.KullaniciAdi = _configuration["MailKullanici : Username"];//* iç içe verilere ulaşma yöntemi
            //*ViewBag.Sifre = _configuration["MailKullanici: Password"]; //1.Yöntem

            ViewBag.Sifre = _configuration.GetSection
            ("MailKullanici : Password").Value;//*2.Yöntem
            
            return View();
        }

       
    }
}