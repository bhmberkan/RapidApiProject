using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Eror404()
        {
            return View();
        }
    }
}
