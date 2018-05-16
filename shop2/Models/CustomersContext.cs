using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shop2.Models
{
    public class CustomersContext : DbContext, ICustomersContext
    {
        public CustomersContext() : base("name=CustomersContext")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public void MarkAsModified(Object item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}