using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;

namespace RentingWebsite.Controllers
{
    public class BasketController : Controller
    {
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Basket = GetCart(),
                ReturnUrl = returnUrl
            });

        }
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            RentingWebsiteEntities db = new RentingWebsiteEntities();
            var cart = GetCart();
            var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1); //add one quantity of this product
            }
            return RedirectToAction("Index", new { returnUrl = returnUrl});
        }
        public RedirectToRouteResult RemoveFromCart(Basket cart, int productId, string returnUrl)
        {
            RentingWebsiteEntities db = new RentingWebsiteEntities();
            var product = db.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveItem(product);

            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Basket GetCart()
        {
            Basket cart = (Basket)Session["Cart"];
            if (cart == null)
            {
                cart = new Basket();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}