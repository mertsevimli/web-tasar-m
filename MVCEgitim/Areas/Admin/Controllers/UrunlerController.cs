using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCEgitim.Models;

namespace MVCEgitim.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UrunlerController : Controller
    {
        private readonly UyeContext _context;

        public UrunlerController(UyeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(string q = "")
        {
            var model = await _context.Urunler.Where(u => u.Adi.Contains(q)).ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Urun urun, IFormFile? Resmi) //* Form içindeki file inputunun name kısmında Resmi yazdığı için bıraya böyle yazdık, yoksa resim dosyasını yakalayamıyoruz.!
        {
            if (ModelState.IsValid)
            {
                if (Resmi is not null)
                {
                    string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                    using var stream = new FileStream(klasor + Resmi.FileName, FileMode.Create);
                    Resmi.CopyTo(stream);
                    urun.Resmi = Resmi.FileName; //* Eklenecek olan ürünün resim bilgisi yüklenen dosyanın dosya adı olsun.
                }

                await _context.Urunler.AddAsync(urun);
                var sonuc = await _context.SaveChangesAsync();
                if (sonuc > 0)
                {
                    TempData["Mesaj"] = "<div class = 'alert alert-primary'> Kayıt eklendi </div>";
                    return RedirectToAction("Index");
                }
            }
            return View(urun);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var model = await _context.Urunler.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Urun urun, IFormFile? Resmi)
        {
            if (ModelState.IsValid)
            {
                if (Resmi is not null)
                {
                    string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Images/"; // dosyayı yükleyeceğimiz klasör
                    using var stream = new FileStream(klasor + Resmi.FileName, FileMode.Create);
                    Resmi.CopyTo(stream);
                    urun.Resmi = Resmi.FileName; //* Eklenecek olan ürünün resim bilgisi yüklenen dosyanın dosya adı olsun.
                }
                _context.Urunler.Update(urun);
                var sonuc = await _context.SaveChangesAsync();
                if (sonuc > 0)
                    return RedirectToAction("Index");
            }
            return View(urun);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var model = await _context.Urunler.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Urun urun, int id)
        {
            _context.Urunler.Remove(urun);
            var sonuc = await _context.SaveChangesAsync();
            if (sonuc > 0)
                return RedirectToAction("Index");
            return View(urun);
        }
    }
}
