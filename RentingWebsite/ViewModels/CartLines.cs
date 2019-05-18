using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;

namespace RentingWebsite.ViewModels
{
    public class CartLines
    {
        /// to represent a product selected by the customer and the quantity the user wants to buy
        public Product Product { get; set; }
        public int Quantity { get; set; }
        ///end public class CartLine
        ///
    }
}