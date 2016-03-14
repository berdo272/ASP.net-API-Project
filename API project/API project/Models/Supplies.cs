using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_project.Models
{
    public class Supplies
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal UsePrice { get; set; }
        public string Notes { get; set; }
    }
}