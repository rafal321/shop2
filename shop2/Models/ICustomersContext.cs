using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shop2.Models
{
    public interface ICustomersContext : IDisposable
    {
        DbSet<Customer> Customers { get; }
        int SaveChanges();
        void MarkAsModified(Object item);
    
    }
}