using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCEgitim.Controllers
{
    [Route("[controller]")]
    public class MVC01RazorSyntaxController : Controller
    {
        private readonly ILogger<MVC01RazorSyntaxController> _logger;

        public MVC01RazorSyntaxController(ILogger<MVC01RazorSyntaxController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}