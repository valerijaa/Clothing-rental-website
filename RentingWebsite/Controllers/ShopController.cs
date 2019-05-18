using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;
using System.Threading.Tasks;

namespace RentingWebsite.Controllers
{
    public class ShopController : Controller
    {
       
        // GET: Shop
        RentingWebsiteEntities db = new RentingWebsiteEntities();

        //View all products
        public ActionResult Index()
        {
            //Product product = db.Products.Find();
            var products = db.Products.Include(p => p.FitProduct)
                                      .Include(p => p.Image);
                              
            ViewBag.ImageId = new SelectList(db.Images, "ImageId", "ImageTitle");
            return View(products.ToList());

            //var query =
            //    from Product
            //    join Image
            //    on Product.ImageId equals Image.ImageId
            //    select Product.Title, Product.Price, Image.ImageURL;
        }
       
        //public async Task<ActionResult> RenderImage(int id)
        //{
        //    Image image = await db.Images.FindAsync(id);

        //    byte[] photoBack = image.ImageURL;

        //    return File(photoBack, "image/jpg");
        //}
        //public ActionResult GetImage()
        //{
        //    byte[] imageByteData = Yourmodel.yourtable...yourImage;
        //    return File(imageByteData, "image/png");
        //}

        //Order by type
        //public ActionResult Type()
        //{
        //    var products = from p in db.Products
        //                   orderby p.Types.GetType ascending
        //                   select p;
        //    return View();
        //}

        //Order by price
        //public ActionResult Price()
        //{
        //    var products = from p in db.Products
        //                   orderby p.Types.GetType ascending
        //                   select p;
        //    return View();
        //}



        //    //var products = db.Products.Include(p => p.Image)
        //    //.Where(t => Type.TypeId == null || t.TypeId == typeId)
        //    //.OrderBy(p => p.ProductId)

        //    return View();
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        RentingWebsiteEntities db = new RentingWebsiteEntities();
        //    //    Products = RentingWebsiteEntities.Products

        //    //    //Update the Catalog so that the Index action will filter the Product objects
        //    //    .Where(p => Product.TypeId == null || p.TypeId == typeId)  //If category is not null, only those Product objects with a matching Category property are selected
        //    //    .OrderBy(p => p.ProductId) //Get the product objects and order them by ProductId
        //    //    .Skip((page - 1) * PageSize) //Skip over the products thta occur before the start of the current page 
        //    //    .Take(PageSize), //Take the number of products specified by the PageSize field

        //    //    //Adding the PagingInfo method to diplay the details of the pagination
        //    //    PagingInfo = new PagingInfo
        //    //    {
        //    //        CurrentPage = page,
        //    //        ItemsPerPage = PageSize,
        //    //        TotalItems = category == null ?
        //    //        RentingWebsiteEntities.Products.Count() :
        //    //        RentingWebsiteEntities.Products.Where(e => e.Category == category).Count() //the pagination information takes the categories into account
        //    //    },
        //    //    CurrentCategory = category //set the value of the CurrentCategory property we added to the ProductsListViewModel class
        //};
        //        //These changes pass a ProductsListViewModel object as the model data to the view
        //    return View(model);


    }
}