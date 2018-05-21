using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using shop2.Models;

namespace shop2.Controllers
{
    [RoutePrefix("shop2")]
    public class CustomerAPIController : ApiController
    {
        private shopdbEntities db = new shopdbEntities();

        [Route("api/Customer/all")]
        // GET: api/CustomerAPI = /shop2/api/Customer/all
        public List<Customer> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.OrderByDescending(x => x.CName).ToList();
        }

        [Route("api/customer/ById/{id}")]
        // GET: /shop2//api/customer/ById/2
        public Customer Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.SingleOrDefault(x => x.CustomerID == id);
        }

        [Route("api/customer/ByKeyword/{Keyword}")]
        public IHttpActionResult GetAllcustomersByKeyword(string keyword)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var result = db.Customers.Where(m => m.CName.Contains(keyword)).Select(m => new { m.CustomerID, m.CName });
            if (result.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [Route("api/customer/New")]
        // POST: api/Customer/New
        public HttpResponseMessage Post([FromBody] Customer value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to read Input");
            }
            if (db.Customers.Count(p => p.CName.Equals(value.CName)) != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Customer" + value.CName + "Already exists in database.");
            }
            db.Customers.Add(value);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, "Customer " + value.CName + "added to database. ");
        }

       

    }
}
