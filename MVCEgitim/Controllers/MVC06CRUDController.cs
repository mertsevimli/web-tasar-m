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
    public class MVC06CRUDController : Controller
    {
        UyeContext uyeContext = new(); // veritabanı tablolarımızı tutan context sınıfımız

        UyeContext _context; // 2. yöntem dependency injection ile nesne örneği oluşturma

        public MVC06CRUDController(UyeContext uyeContext) // kurucu metoda ilgili
        {
            _context = uyeContext;
        }

        // GET: MVC06CRUDController

        public ActionResult Index()
        {
            // var model = uyeContext.Uyeler.ToList(); // veritabanından üye listesini çek
            var model = _context.Uyeler.ToList();

            return View(model); // ekranda model olarak kullanılmak üzere view a gönder
        }

        // GET: MVC06CRUDController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MVC06CRUDController/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC06CRUDController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uye uye)
        {
            if (ModelState.IsValid) //model kurallanıa uyulduysa
            {
                try
                {
                    _context.Uyeler.Add(uye); // _context nesnesi üzerindeki uyeler tablosuna ekrandan gelen uye nesnesini ekle
                    _context.SaveChanges(); // yukarıda yapılan ekleme işlemini kaydet
                    return RedirectToAction(nameof(Index)); // kayıttan sonra sayfayı Index e yönlendir.
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(uye);
        }

        // GET: MVC06CRUDController/Edit/5

        public ActionResult Edit(int id)
        {
            var model = _context.Uyeler.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: MVC06CRUDController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Uye uye)
        {
            if (ModelState.IsValid) //model kurallanıa uyulduysa
            {
                try
                {
                    _context.Uyeler.Update(uye); // _context nesnesi üzerindeki uyeler tablosuna ekrandan gelen uye nesnesini ekle
                    _context.SaveChanges(); // yukarıda yapılan ekleme işlemini kaydet
                    return RedirectToAction(nameof(Index)); // kayıttan sonra sayfayı Index e yönlendir.
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(uye);
        }

        // GET: MVC06CRUDController/Delete/5

        public ActionResult Delete(int id)
        {
            var model = _context.Uyeler.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: MVC06CRUDController/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Uye uye)
        {
            try
            {
                _context.Uyeler.Remove(uye);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
