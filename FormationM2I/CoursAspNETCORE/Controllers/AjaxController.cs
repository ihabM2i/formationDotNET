using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNETCORE.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult First()
        {
            return PartialView();
        }

        public IActionResult Second()
        {
            return PartialView();

        }
    }
}