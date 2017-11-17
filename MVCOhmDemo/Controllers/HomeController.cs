using MVCOhmDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOhmDemo.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index()
        {
            // Setup model before passing in
            var model = new COhmModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string firstSignificantFigure = formCollection["BandAColor"];
            string secondSignificantFigure = formCollection["BandBColor"];
            string multiplierColor = formCollection["BandCColor"];
            string toleranceColor = formCollection["BandDColor"];
            var model = new COhmModel(firstSignificantFigure, secondSignificantFigure, multiplierColor, toleranceColor);
            model.CalculateOhmValue(firstSignificantFigure, secondSignificantFigure, multiplierColor, toleranceColor);
            return View(model);
        }

        
    }
}
