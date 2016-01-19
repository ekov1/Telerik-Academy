using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SumNumbersMVC.Controllers
{
    using System.Diagnostics;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index(double? sum)
        {
            if (sum != null)
            {
                ViewData["Sum"] = sum;
            }

            return View();
        }

        public ActionResult SumNumber(Summator summator)
        {
            var sum = summator.A + summator.B;

            return RedirectToAction("Index", new {sum});
        }
    }
}