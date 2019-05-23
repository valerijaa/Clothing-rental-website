using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;

//wrap all of the data that us connected to the Products, Category and PagingInfo and send it to the Catalogcontroller 
namespace RentingWebsite.Controllers
{


    public class ShopController : Controller
    {
        /////update the Catalogue controller so that the Index action method will filter Product objects by category
        //public int PageSize = 4; //it specifies that we want 4 products per page

        // GET: Shop
        RentingWebsiteEntities db = new RentingWebsiteEntities();

        public ActionResult Filtered([FromUri] string colors, [FromUri] string sizes, [FromUri] string types, [FromUri] string fits)
        {
            // values are comma separated
            var selectedColorIds = colors.Split(',').Where(w => !String.IsNullOrWhiteSpace(w)).Select(int.Parse);
            var selectedSizeIds = sizes.Split(',').Where(w => !String.IsNullOrWhiteSpace(w)).Select(int.Parse);
            var selectedTypeTitles = types.Split(',').Where(w => !String.IsNullOrWhiteSpace(w));
            var selectedFitIds = fits.Split(',').Where(w => !String.IsNullOrWhiteSpace(w)).Select(int.Parse);

            var products = db.Products.Where(product =>
                ( selectedColorIds.Count() == 0 || product.Colors.Any(color => selectedColorIds.Contains(color.ColorId)))
                && (selectedSizeIds.Count() == 0 || product.Sizes.Any(size => selectedSizeIds.Contains(size.SizeId)))
                && (selectedTypeTitles.Count() == 0 || selectedTypeTitles.Contains(product.Category))
                && (selectedFitIds.Count() == 0 || (product.FitProductId.HasValue && selectedFitIds.Contains(product.FitProductId.Value) ))
            ).ToList();

            return View("Index", products);
        }

        //View all products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.FitProduct)
                                      .Include(p => p.Image);

            return View(products.ToList());
        }




        public ActionResult ProductDetails(int? id)
        {
            RentingWebsiteEntities db = new RentingWebsiteEntities();

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }


            return View(product);
        }







    }

}




