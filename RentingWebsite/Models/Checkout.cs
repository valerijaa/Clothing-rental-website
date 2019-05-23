
namespace RentingWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Checkout
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<int> Zip { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public Nullable<int> CreditCard { get; set; }
    }
}
