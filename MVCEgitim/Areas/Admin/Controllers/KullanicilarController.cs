using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCEgitim.Models;

namespace MVCEgitim.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class KullanicilarController : Controller
    {
        private readonly UyeContext _context;

        public KullanicilarController(UyeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Uyeler.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Uye uye)
        {
            //* Bir metodun içerisinde askenron işlemler varsa (aşağıdaki kayıt ekleme gibi ) metodun kendisi( Create metodu ) de asenkron yapılır ve bir task içerisinde yer alır.  Ampuldan make Async seciceksin.


            if (ModelState.IsValid)
            {
                try
                {
                    //*Senkron ekleme
                    // _context.Uyeler.Add(uye);
                    // var sonuc = _context.SaveChanges();
                    //ASenkron ekleme
                    await _context.Uyeler.AddAsync(uye);
                    var sonuc = await _context.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                         TempData["Mesaj"] =
                            "<div class='alert alert-info'>Kayıt Eklendi </div> ";
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }
            return View(uye);
        }

        public async Task<IActionResult> Edit(int id)
        {
            //Senkron kayıt arama
            // var model = _context.Uyeler.Find(id);
            //Asenkron kayıt arama
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Uye uye) //* Bu modeller önemli bunlara çalış !!!
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Uyeler.Update(uye);
                    var sonuc = await _context.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                        TempData["Mesaj"] =
                            "<div class='alert alert-primary'>Kayıt Güncellendi </div> ";
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }
            return View(uye);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var model = await _context.Uyeler.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id, Uye uye)
        {
            _context.Uyeler.Remove(uye);
            
            var sonuc = await _context.SaveChangesAsync();
            if (sonuc > 0)
            {
                TempData["Mesaj"] = "<div class='alert alert-danger'>Kayıt Silindi </div> ";
                return RedirectToAction("Index");
            }
            return View(uye);
        }
    }
}
