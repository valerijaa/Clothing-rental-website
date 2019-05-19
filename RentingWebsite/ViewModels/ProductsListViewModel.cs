using RentingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//wrap all of the data that us connected to the Products, Category and PagingInfo and send it to the Catalogcontroller 
namespace RentingWebsite.ViewModels
{
    public class ProductsListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; } //Communicate the current category to the view in order to render the sidebar

    }
}