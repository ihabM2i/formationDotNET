using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNETCORE.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult() { Content= "<h1>Bonjour tout le monde</h1>", ContentType="text/html" };
        }

        public IActionResult Contact()
        {
            return new JsonResult(new { Nom="abadi", Prenom="Ihab"});
        }

        public IActionResult FirstView()
        {
            return View();
        }

        public IActionResult SecondView()
        {
            return View("FirstView");
        }

        public IActionResult ThirdView()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }
    }
}