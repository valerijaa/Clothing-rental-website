using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentingWebsite.ViewModels
{
    public class FilterForm
    {
        public List<FilterItem> Types { get; set; }
        public List<FilterItem> Sizes { get; set; }
        public List<FilterItem> Colors { get; set; }
        public List<FilterItem> Fits { get; set; }
    }
}