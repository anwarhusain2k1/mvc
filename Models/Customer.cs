using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Customer
    {
        public int Customerid { get; set; }
        public string CustomerName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Nullable<int> LoyaltyPoints { get; set; }
    }
}