using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoursAspNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoursAspNETCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateSession()
        {
            List<Personne> liste = new List<Personne>()
            {
                new Personne() { Nom = "tata", Prenom = "toto"},
                new Personne() { Nom = "titi", Prenom = "minet"},
            };
            HttpContext.Session.SetString("liste", JsonConvert.SerializeObject(liste));            
            return View();
        }

        public IActionResult ReadSession()
        {
            //ViewBag.Nom = HttpContext.Session.GetString("nom");
            ViewBag.Liste = JsonConvert.DeserializeObject<List<Personne>>(HttpContext.Session.GetString("liste"));
            return View();
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("ReadSession");
        }

        public IActionResult CreateCookie()
        {
            CookieOptions option = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(2)
            };
            HttpContext.Response.Cookies.Append("nom", "abadi", option);
            return View();
        }

        public IActionResult ReadCookie()
        {
            
            ViewBag.Nom = HttpContext.Request.Cookies["nom"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
