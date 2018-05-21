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
        public void EditCustomerTest()
        {
            TestCustomersContext C = new TestCustomersContext();
            CustomerController controller = new CustomerController(C);
            Customer customerToEdit = new Customer() { CustomerID = 13, CName = "Bob", CAddress = "Tallaght", Phone = "08744458" };

            var result = controller.Edit(customerToEdit) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

    }
}




