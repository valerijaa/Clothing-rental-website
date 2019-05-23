using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;

namespace RentingWebsite.ViewModels
{
    public class CartIndexViewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
    }
}

