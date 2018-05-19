using Microsoft.VisualStudio.TestTools.UnitTesting;
using shop2.Controllers;
using shop2.Models;
using System.Web.Mvc;

namespace shop2Tests2
{
    [TestClass]
    class TestCustomerController
    {
        [TestMethod()]

        public void CreateCustomerTest()
        {
            TestCustomersContext tbc = new TestCustomersContext();
            CustomerController controller = new CustomerController(tbc);
            Customer customerToCreate = new Customer() { CustomerID = 13, CName = "Bob", CAddress = "Tallaght", Phone = "four" };
            // Act

            var result = controller.Create(customerToCreate) as RedirectToRouteResult;

            // Assert

            Assert.AreEqual("Index", result.RouteValues["action"]);

        }


       [TestMethod()]

        public void IndexTestNameLike()

        {

        //    //Arrange

        //    TestCustomersContext tbc = new TestCustomersContext();

        //    CustomerController controller = new CustomerController(tbc);

        //    Customer Carol = new MeetingRoom() { Name = "Chat Room", Size = 4, Location = "Ground Floor" };

        //    MeetingRoom room2 = new MeetingRoom() { Name = "Board Room", Size = 8, Location = "First Floor" };

        //    tbc.MeetingRooms.Add(room1);

        //    tbc.MeetingRooms.Add(room2);

        //    // Act

        //    ViewResult result = controller.Index("", "hat") as ViewResult;

        //    // Assert

        //    var rooms = (List<MeetingRoom>)result.ViewData.Model;

        //    foreach (var r in rooms)

        //    {

        //        StringAssert.Contains(r.Name, "hat");

        //    }

        //    Assert.AreEqual(1, rooms.Count);

        //}

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
}
