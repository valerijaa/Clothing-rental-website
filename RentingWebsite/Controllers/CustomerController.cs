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
    public class CustomerController : Controller
    {


        [HttpGet]
        // GET: Customer
        public ActionResult AddOrEdit(int id = 0)
        {
            Customer customerModel = new Customer();
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                RentingWebsiteEntities2 db = new RentingWebsiteEntities2();
                db.Customer.Add(customer);
                db.SaveChanges();
            }
            return View(customer);
        }
        //    public ActionResult AddOrEdit(Customer customer)
        //    {
        //    using (RentingWebsiteEntities2 rentingWebsiteEntities2 = new RentingWebsiteEntities2())
        //   {
        //       RentingWebsiteEntities2 db = new RentingWebsiteEntities2();
        //     
        //      if (db.Customer.Any(x => x.Username == customer.Username))
        //      {
        //           ViewBag.DuplicateMessage = "Username already taken";
        //            return View("AddOrEdit", db);
        //       }
        //       db.Customer.Add(customer);
        //      db.SaveChanges();
        // }
        //  ModelState.Clear();
        // ViewBag.SuccesMessage = "Registration Successful";
        // return View("AddOrEdit", new Customer());
    }

 }

