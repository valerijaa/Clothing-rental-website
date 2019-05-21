﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentingWebsite.Models
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string RentDuration { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}