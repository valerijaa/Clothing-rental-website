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
            var selectedTypeIds = types.Split(',').Where(w => !String.IsNullOrWhiteSpace(w)).Select(int.Parse);
            var selectedFitIds = fits.Split(',').Where(w => !String.IsNullOrWhiteSpace(w)).Select(int.Parse);

            var products = db.Products.Where(product =>
                ( selectedColorIds.Count() == 0 || product.Colors.Any(color => selectedColorIds.Contains(color.ColorId)))
                && (selectedSizeIds.Count() == 0 || product.Sizes.Any(size => selectedSizeIds.Contains(size.SizeId)))
                && (selectedTypeIds.Count() == 0 || product.Types.Any(type => selectedTypeIds.Contains(type.TypeId)))
                && (selectedFitIds.Count() == 0 || (product.FitProductId.HasValue && selectedFitIds.Contains(product.FitProductId.Value) ))
            ).ToList();

            return View("Index", products);
        }

        //View all products
        public ActionResult Index(/*string Category*/)
        {
            var products = db.Products.Include(p => p.FitProduct)
                                    .Include(p => p.Image);
            return View(products.ToList());
        }

        //Order by Category
        public ActionResult Category(string Category)
        {
            var products = db.Products.Include(p => p.FitProduct)
                                      .Include(p => p.Image);
            products = db.Products
               //Update the Catalog so that the Index action will filter the Product objects
               .Where(p => p.Category == null || p.Category == p.Category)  //If category is not null, only those Product objects with a matching Category property are selected
               .OrderBy(p => p.ProductId); //Get the product objects and order them by ProductId
       
                        //.Skip((page - 1) * PageSize) //Skip over the products thta occur before the start of the current page 
                        //.Take(PageSize); //Take the number of products specified by the PageSize field
                        //                 //Adding the PagingInfo method to diplay the details of the pagination
                        //PagingInfo = new PagingInfo
                        //{
                        //    CurrentPage = page,
                        //    ItemsPerPage = PageSize,
                        //    TotalItems = Category == null ?
                        //    db.Products.Count() :
                        //    db.Products.Where(e => e.Category == Category).Count() //the pagination information takes the categories into account
                        //};
                       var CurrentCategory = Category;


            //These changes pass a ProductsListViewModel object as the model data to the view
            return View(products.ToList());

        }
        //Order by Category
        public ActionResult Price()
        {
            RentingWebsiteEntities db = new RentingWebsiteEntities();
            var products = db.Products.Include(p => p.FitProduct)
                                      .Include(p => p.Image);
            products = db.Products
                   //Update the Catalog so that the Index action will filter the Product objects
                   .Where(p => p.Price == null || p.Price == p.Price)  //If category is not null, only those Product objects with a matching Category property are selected
                      .OrderBy(p => p.ProductId);

            return View();
        }

        


    }

}




