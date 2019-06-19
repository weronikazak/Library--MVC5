using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Models
{
    public class RentalController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save()
        {
            return View();
        }
    }
}