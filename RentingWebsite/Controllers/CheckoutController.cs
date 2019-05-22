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
            int s = (int)Session["CustomerId"];
            System.Diagnostics.Debug.WriteLine(s);
            Checkout c = new Checkout();
            return View(c);
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {

                RentingWebsiteEntities2 db = new RentingWebsiteEntities2();

                //var a = Session["LoggedUser"];
               

                //int ses = HttpContext.Session["LoggedUser"];



                int s = (int)Session["CustomerId"];
                //var check = db.Customer.Single(p => p.CustomerId == c );
                //UpdateModel(c);

              

                //string firstname = a[1];
                //string lastname = a[2].ToString();
                //string address = a[3].ToString();
                //string zip = a[4].Trim();
                //string phonenumber = a[5].Trim();
                //string creditcard = a[6].Trim();
               

                //var data = db.Customer.SingleOrDefault(row => row.CustomerId == s );


                //Customer customcer = new Customer();
                customer = db.Customer.Find(s);
                db.Entry(customer).State = EntityState.Modified;

                using (var con = new RentingWebsiteEntities2())
                {
                    customer = con.Customer.SingleOrDefault(x => x.CustomerId == s);
                    //customer.CustomerId = s;

                    con.Customer.Attach(customer);
                    var entry = con.Entry(customer);
                    entry.Property(e => e.FirstName).IsModified = true;
                    System.Diagnostics.Debug.WriteLine(customer.FirstName);
                    con.SaveChangesAsync();
                }
               
                //db.SaveChanges();
                //data.FirstName = firstname;
                //data.LastName = lastname;
                //data.Address = address;
                //data.Zip = Convert.ToInt16(zip);
                //data.PhoneNumber = Convert.ToInt16(phonenumber);
                //data.CreditCard = Convert.ToInt16(creditcard);

                //System.Diagnostics.Debug.WriteLine(zip);
                //System.Diagnostics.Debug.WriteLine(phonenumber);
                //using (var con = new RentingWebsiteEntities2())
                //{
                //    data.FirstName.Attach(firstname);
                //}


                //db.SaveChanges();





                //result.is_default = false;



                //db.Customer.Add(c);
                //db.SaveChanges();

                //System.Diagnostics.Debug.WriteLine(s);
                //System.Diagnostics.Debug.WriteLine(firstname);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}