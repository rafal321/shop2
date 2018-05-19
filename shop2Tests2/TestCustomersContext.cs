using shop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace shop2Tests2
{
    public  class TestCustomersContext : ICustomersContext
    {
        public TestCustomersContext()
        {
            this.Customers = new TestCustomerDbSet();
        }

        public DbSet<Customer> Customers { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Object item) { }
        public void Dispose() { }
    }
}
