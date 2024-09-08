using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims; //oturum açmak için gerekli
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication; //* oturum açmak için gerekli
using Microsoft.AspNetCore.Authorization; //Authorize attributeünü kullanmak için
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCEgitim.Filters; //yazdığımız filtrenin usingi buraya ekliyoruz.
using MVCEgitim.Models;

namespace MVCEgitim.Controllers
{
    public class MVC15FiltersUsingController : Controller
    {
        private readonly UyeContext _context;

        public MVC15FiltersUsingController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [UserControl] //FiltreKullanimi Action ı çalıştığında usercontrol çalışır
        public IActionResult FiltreKullanimi()
        {
            return View();
        }

        [Authorize] //* Authorize attribute ü altındaki action ı oturum açılmamışsa korur ve ekrarnın açılmasını engeller.
        public IActionResult UyeGuncelle(int? id)
        {
            if (id == null) // eğer adres çubuğundan id gönderilmezse
            {
                return BadRequest(); //* geriye geçersiz istek hatası döndür.
            }
            Uye uye = _context.Uyeler.Find(id); // gönderilen id ye göre veritabanında arama yap
            if (uye == null) //* eğer db de kayıt bulamazsan
                return NotFound(); //* geriye not found - kayıt bulunamadı ekranı göster.
            return View(uye);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UyeGuncelle(int? id, Uye uye)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Uyeler.Update(uye);
                    _context.SaveChanges();
                }
                catch (System.Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }

            return View(uye);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Uye uye)
        {
            try
            {
                Uye admin = _context.Uyeler.FirstOrDefault(u =>
                    u.Email == uye.Email && u.Sifre == uye.Sifre
                ); //1.Yöntem
                if (admin is not null)
                {
                    //*Kullanıcıya giriş için vermek istediğimiz hakları tanımlıyoruz.
                    var haklar = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, admin.Email),
                        new Claim(ClaimTypes.Role, "Admin"),
                    };
                    //*Kullanıcıya kimlik tanımlıyoruz.
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); //* Kullanıcıya tanımladığımız hakları kimliğe işliyoruz.
                    //*Kullanıcıya verdiğimiz kimlik ile tanımlı kurallardan oluşan nesne oluşturuyoruz.
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi); //* Yetkilendirme ile sismeye giriş yapıyoruz.
                    await HttpContext.SignInAsync(claimsPrincipal);
                    //*Giriş sonrası tarayıcıda return url varsa
                    if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]))
                    {
                        return Redirect(HttpContext.Request.Query["ReturnUrl"]); //kullanıcıyı ReturnUrl deki gitmek istediği adrese yönlendir.
                    }
                    return RedirectToAction("Index"); //ReturnUrl yoksa anasayfaya yönlendir.
                }
            }
            catch (System.Exception hata)
            {
                ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
            }
            return View(uye);
        }
        [HttpPost] 
         public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
