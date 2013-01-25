using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCJsonPost.Models;

namespace MVCJsonPost.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PersonModel());
        }

        [HttpPost]
        public JsonResult BadSave(string first, string last, List<string> favoriteBands)
        {
            return Json(new { result = "saved the bad way" });
        }

        [HttpPost]
        public JsonResult GoodSave(PersonModel model)
        {
            return Json(new { result = "saved the good way" });
        }
    }
}
