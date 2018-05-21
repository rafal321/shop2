using Microsoft.VisualStudio.TestTools.UnitTesting;
using shop2.Controllers;
using shop2.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace shop2Tests2
{
    [TestClass]
    public class TestCustomerController
    {

        [TestMethod()]

        public void CreateCustomerTest()
        {
            TestCustomersContext C = new TestCustomersContext();
            CustomerController controller = new CustomerController(C);
            Customer customerToCreate = new Customer() { CustomerID = 13, CName = "Bob", CAddress = "Tallaght", Phone = "08744458" };

            var result = controller.Create(customerToCreate) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod()]

        public void IndexTestSpecficWord()

        {

            TestCustomersContext c = new TestCustomersContext();

            CustomerController controller = new CustomerController(c);

            Customer Customer1 = new Customer() { CName = "Bob", CAddress = "Dublin", };

            c.Customers.Add(Customer1);

            ViewResult result = CustomerController.Index("", "Dublin") as ViewResult;

            var customers = (List<Customer>)result.ViewData.Model;

            foreach (var r in customers)

            {

                StringAssert.Contains(r.CAddress, "Dublin");

            }

            Assert.AreEqual(1, customers.Count);

        }
       

    }
}




