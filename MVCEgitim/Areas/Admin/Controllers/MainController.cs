using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCEgitim.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]//*Aşağıdaki controller admin altında çalışsın
    public class MainController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] 
     public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}