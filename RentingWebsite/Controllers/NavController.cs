using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;

namespace RentingWebsite.Controllers
{
    public class NavController : Controller
    {
        // Integrate a child action to include the output from an arbitrary action method in the current view
        //GET: Nav and create the list of categories on the right sidebar
        public PartialViewResult Nav(string category = null)
        {
            RentingWebsiteEntities db = new RentingWebsiteEntities();

            ViewBag.SelectedCategory = category; //the ViewBag allows us to pass data from the controller to the view without using a view model.
            IEnumerable<string> categories = db.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);

            //ViewBag.SelectedSize = size; //the ViewBag allows us to pass data from the controller to the view without using a view model.
            //IEnumerable<string> sizes = db.Products
            //.Select(x => s.Size)
            //.Distinct()
            //.OrderBy(s => s);
            //return PartialView(sizes;
        }
    }
}