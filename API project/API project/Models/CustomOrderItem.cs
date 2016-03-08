using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_project.Models
{
    public class CustomOrderItem
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime EstimatedTimeOfCompletion { get; set; }
        public string SellersNotes { get; set; }

    }
}