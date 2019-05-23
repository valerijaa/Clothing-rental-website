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
using System.Web.Helpers;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace RentingWebsite.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        // GET: Checkout
        public ActionResult Index(int id = 0)
        {
            //    int s = (int)Session["CustomerId"];
            //    System.Diagnostics.Debug.WriteLine(s);
            Checkout c = new Checkout();
            return View(c);
        }

        [HttpPost]
        public ActionResult Index(Checkout checkout)
        {
            RentingWebsiteEntities2 db = new RentingWebsiteEntities2();

            if (ModelState.IsValid)
            {

                int s = (int)Session["CustomerId"];

                var customer = db.Customer.SingleOrDefault(row => row.CustomerId == s);


               customer.ConfirmPassword = customer.Password;
                customer.Email = checkout.Email;
                customer.Zip = checkout.Zip;
                customer.FirstName = checkout.FirstName;
                customer.LastName = checkout.LastName;
                customer.PhoneNumber = checkout.PhoneNumber;
                customer.CreditCard = checkout.CreditCard;
                customer.Address = checkout.Address;

                db.Entry(customer).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("Record updated:  \"{0}\"", s);
                    System.Diagnostics.Debug.WriteLine("new First name:  \"{0}\" ,  \"{1}\"   ", customer.FirstName, checkout.FirstName);

                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    //  throw;
                }
                // System.Diagnostics.Debug.WriteLine(s);
                //System.Diagnostics.Debug.WriteLine(firstname);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}