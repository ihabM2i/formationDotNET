using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNETCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNETCORE.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["contacts"] = Contact.GetContacts();
            //ViewBag.Contacts = Contact.GetContacts();
            return View(Contact.GetContacts());
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}