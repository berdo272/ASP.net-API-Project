using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_project.Models
{
    public class ChainmailDBContext : DbContext
    {
        public ChainmailDBContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<CustomOrder> CustomOrders { get; set; }
        public DbSet<FinishedItem> FinishedItems { get; set; }
        public DbSet<CustomOrderItem> CustomItems { get; set; }
    }
}