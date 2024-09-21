using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //*Classı viewComponents haline getirmek için
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCEgitim.Models;

namespace MVCEgitim.ViewComponents
{
    public class Uyeler : ViewComponent //* Uyeler sınıfına ViewComponent sınıfından kalıtım alıyoruz.
    {
        private readonly UyeContext _context; //  _context e sağ click ampul üzerinden genaret cpntructos constructor

        public Uyeler(UyeContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Uyeler.ToListAsync());
        }
    }
}
