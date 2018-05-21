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
            Customer customerToCreate = new Customer() { CustomerID = 13, CName = "Bob", CAddress = "Tallaght", Phone = "four" };

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

            ViewResult result = controller.Index("", "Dublin") as ViewResult;

            var customers = (List<Customer>)result.ViewData.Model;

            foreach (var r in customers)

            {

                StringAssert.Contains(r.CAddress, "Dublin");

            }

            Assert.AreEqual(1, customers.Count);

        }
        [TestMethod()]


        public void DetailsTest()

        {
            TestCustomersContext c = new TestCustomersContext();

            CustomerController controller = new CustomerController(c);

            Customer customerToAdd = new Customer() { CName = "Dan", CAddress = "The Gables", Phone = "tWO" };

            c.Customers.Add(customerToAdd);

            ViewResult result = CustomerController.Details("Dan") as ViewResult;

            var Customer = (CustomerController)result.ViewData.Model;

            Assert.AreEqual(CustomerController.CName, "Dan");

            Assert.AreEqual(CustomerController.CAddress, "The Gables");

        }
    }
}




