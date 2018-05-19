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
            TestCustomersContext tbc = new TestCustomersContext();
            CustomerController controller = new CustomerController(tbc);
            Customer customerToCreate = new Customer() { CustomerID = 13, CName = "Bob", CAddress = "Tallaght", Phone = "four" };
         
            var result = controller.Create(customerToCreate) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);

        }
        //[TestMethod()]

        //public void GetDetailsTest()
        //{
        //    TestCustomersContext tbc = new TestCustomersContext();
        //    CustomerController controller = new CustomerController(tbc);
        //    Customer GetDetails = Customer (1);

        //    var result = controller.Index(customerToCreate) as RedirectToRouteResult;

        //    Assert.AreEqual("Index", result.RouteValues["action"]);

       [TestMethod()]

        public void IndexTestSpecficWord()

        {

       TestCustomersContext a = new TestCustomersContext();

        CustomerController controller = new CustomerController(a);

        Customer Customer1 = new Customer() { CName = "Bob", CAddress = "Dublin", Phone = "two" };

        a.Customers.Add(Customer1);

       ViewResult result = controller.Index("Dublin") as ViewResult;

        var customers = (List<Customer>)result.ViewData.Model;

            foreach (var r in customers) 

        {

       StringAssert.Contains(r.CAddress, "Dublin");

        }

        Assert.AreEqual(1, customers.Count);

        }

        //[TestMethod()]
        //public void IndexTest()
        //{
        //    TestCustomersContext tdc = new TestCustomersContext();
        //    var controller = new CustomerController(tdc);
        //    var result = controller.Index("Customers");
        //    Assert.IsNotNull(result);
        //}
        //[TestMethod()]
        //public void IndexTest()
        //{
        //    TestCustomersContext tdc = new TestCustomersContext();
        //    CustomerController controller = new CustomerController (tbc);
        //    Customer customer = new Customer() { CName = "Bob" };

        //    var result = controller.Create(cust);
        //    Assert.IsNotNull(result);
    }

}



