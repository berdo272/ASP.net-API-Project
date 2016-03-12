using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_project.Models
{
    public class PaymentViewModel
    {
        public string CustomerID;
        public decimal Shipping = 9;
        public decimal Tax;
        public decimal Price;
        public string ItemName;
        public decimal Total;
        public decimal Subtotal;
    }
}