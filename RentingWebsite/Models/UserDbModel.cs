namespace UserDbModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        public int PhoneNumber { get; set; }
        public int CreditCard { get; set; }


    }
}