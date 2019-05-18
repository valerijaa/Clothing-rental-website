using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;


namespace RentingWebsite.Controllers
{
    public class CartController : Controller
    {
        RentingWebsiteEntities db = new RentingWebsiteEntities();

        // GET: ShoppingCart
        public ViewResult Index(ViewModels.Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        } ///End Index view result

        public RedirectToRouteResult AddToCart(ViewModels.Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1); //add one quantity of this product }
            }

            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }//End public RedirectRoute

        public RedirectToRouteResult RemoveFromCart(ViewModels.Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { controller = "Cart" });
        }//End public RedirectRoute

        public PartialViewResult Summary(ViewModels.Cart cart) //add a widget in the top right that summarizes the contents of the cart 
        {
            return PartialView(cart);
        }
    }
}