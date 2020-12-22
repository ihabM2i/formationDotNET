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

        public IActionResult SubmitForm(Contact contact)
        {
            if(contact.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Form");
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            return View(Contact.GetContactById(id));
        }

        public IActionResult Delete(int id)
        {
            Contact contact = Contact.GetContactById(id);
            if (contact != null)
                contact.Delete();
            return RedirectToAction("Index");
        }

        public IActionResult FormEmail(int id)
        {
            Contact contact = Contact.GetContactById(id);
            if(contact != null)
                return View(contact);
            else
                return RedirectToAction("Index");
        }

        public IActionResult SubmitEmail(Email email, int contactId)
        {
            Contact.AddMail(email, contactId);
            return RedirectToAction("Index");
        }
    }
}