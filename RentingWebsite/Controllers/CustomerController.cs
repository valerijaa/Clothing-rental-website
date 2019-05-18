using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserDbModel.Models;

namespace RentingWebsite.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult AddOrEdit(int id=0)
        {
            Customer customerModel = new Customer();
            return View();
        }
    }
}