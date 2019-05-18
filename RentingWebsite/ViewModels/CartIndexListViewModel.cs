using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;

namespace RentingWebsite.ViewModels
{
    public class CartIndexViewModel
    {
        //properties 
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}