using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNETCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNETCORE.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult First([FromBody]Contact contact)
        {
            ViewBag.Nom = contact.FirstName;
            return PartialView();
        }

        public IActionResult Second([FromForm]string nom)
        {
            return PartialView();

        }
    }
}