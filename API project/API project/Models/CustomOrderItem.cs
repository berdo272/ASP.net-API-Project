using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_project.Models
{
    public class CustomOrderItem
    {
        public int Id { get; set; }
        public string CustomerID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime EstimatedTimeOfCompletion { get; set; }
        public string SellersNotes { get; set; }
        public bool HasBeenPurchased { get; set; }

    }
}