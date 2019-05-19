using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentingWebsite.Models;
using RentingWebsite.ViewModels;

namespace RentingWebsite.ViewModels
{
    public class Cart
    {
        RentingWebsiteEntities db = new RentingWebsiteEntities();
        //Private field
        private List<CartLines> lines = new List<CartLines>();

        //property that gives access to the contents of the cart using a List<CartLine>
        public List<CartLines> Lines
        {
            get { return lines; }
        }
        //Properties
        //Method to calculate the total cost of the items in the cart
        //public decimal TotalPrice
        //{
        //    // Linq syntax 
        //    get { return lines.Sum(e => e.Product.Price * e.Quantity); }
        //}
        // Constructor method to add an item to the cart
        public Cart() { }

        public void AddItem(Product product, int quantity)
        {
            // Check to see if the product is already in the cart 
            CartLines item = lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (item == null)
            {
                lines.Add(new CartLines { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        //Method to remove a previously added item from the cart
        public void RemoveItem(Product product)
        {
            lines.RemoveAll(i => i.Product.ProductId == product.ProductId);
        }

        //reset the cart by removing all of the items
        public void Clear()
        {
            lines.Clear();
        }

    } //end public class Cart

}
