using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCEgitim.ViewComponents
{
    public class iletisim : ViewComponent
    {
          public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}