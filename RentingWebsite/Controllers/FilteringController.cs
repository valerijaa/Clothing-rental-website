using RentingWebsite.Models;
using RentingWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RentingWebsite.Controllers
{
    public class FilteringController : Controller
    {
        RentingWebsiteEntities db = new RentingWebsiteEntities();

        [HttpGet]
        public ActionResult FilteringForm()
        {
            //creting form containing all filtering options
            //var filterform = new FilterForm()
            //{
            //    Types = db.EventTypes.Select(eventType => new FilterItem()
            //    {
            //        Id = eventType.EventId,
            //        Name = eventType.EventTitle
            //    }).ToList(),

            //    Colors = db.Colors.Select(color => new FilterItem()
            //    {
            //        Id = color.ColorId,
            //        Name = color.ColorTitle
            //    }).ToList(),

            //    Sizes = db.Sizes.Select(size => new FilterItem()
            //    {
            //        Id = size.SizeId,
            //        Name = size.SizeTitle
            //    }).ToList(),

            //    Fits = db.FitProducts.Select(fitproduct => new FilterItem()
            //    {
            //        Id = fitproduct.FitProductId,
            //        Name = fitproduct.FitProductTitle
            //    }).ToList()
            //};

            //return Json(filterform, JsonRequestBehavior.AllowGet);
            return View();
        }
    }
}