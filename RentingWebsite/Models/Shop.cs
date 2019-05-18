using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;

namespace RentingWebsite.Models
{
    public class Shop
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Nullable<int> FitProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> ImageId { get; set; }

        public virtual FitProduct FitProduct { get; set; }
        public virtual Image Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Color> Colors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventType> EventTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Size> Sizes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Type> Types { get; set; }

        public virtual Product Product { get; set; }

    }


}