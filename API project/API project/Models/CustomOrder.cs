﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_project.Models
{
    public class CustomOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerID { get; set; }
        public string RequestDescription { get; set; }
    }
}