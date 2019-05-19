using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using RentingWebsite.Models;

namespace RentingWebsite.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["LoggedUser"] == null)
            { return View("AfterLogin"); };
                LoginCustomer customerModel = new LoginCustomer();
            return View(customerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginCustomer c)
        {
            if (Session["LoggedUser"] == null)
            {


                // this action is for handle post (login)
                if (ModelState.IsValid) // this is check validity
                {
                    using (RentingWebsiteEntities2 dc = new RentingWebsiteEntities2())
                    {
                        var v = dc.Customer.Where(model => model.Username.Equals(c.Username) && model.Password.Equals(c.Password)).FirstOrDefault();
                        if (v != null)
                        {
                            Session["LoggedUser"] = v.CustomerId;

                            return RedirectToAction("AfterLogin");
                        }
                        //System.Diagnostics.Debug.WriteLine(v.Username);
                    }

                }
                //return RedirectToAction("AfterLogin");
            }
            return View();
        }
        public ActionResult AfterLogin()
        {
            if (Session["LoggedUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}