using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;
using System.Web.Mvc;

//Creating a model binder to get the values for the parameters of the action method we have targeted 
namespace RentingWebsite.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session 
            ViewModels.Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (ViewModels.Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data 
            //the session helps to store and manage the Cart objects
            if (cart == null)
            {
                cart = new ViewModels.Cart();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // return the cart 
            return cart;
        }
    }
}