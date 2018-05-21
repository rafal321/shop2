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
    public class CustomerAPIController : ApiController
    {
        private shopdbEntities db = new shopdbEntities();

        // GET: api/CustomerAPI
        public List<Customer> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.OrderByDescending(c => c.CName).ToList();

        }
        // GET: api/CustomerAPI/1
        public Customer GetById(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Customers.SingleOrDefault(c => c.CustomerID == id);
        }
        [Route("api/customerAPI/ByKeyword/{keyword}")]
        public IHttpActionResult GetByKeyword(String keyword)
        {
            // return Customer Name and Customer Address for matches whole word only
            var results = db.Customers.Where(c => c.CAddress.Contains(keyword)).Select(c => new { c.CName, c.CAddress });

            if (results.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(results);
            }
        }

        [Route("api/customerAPI/Update/{id}")]

        public HttpResponseMessage Put(int id, [FromBody]Customer value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Failed to read input");
            }

            var record = db.Customers.SingleOrDefault(c => c.CustomerID == id);

            if (record == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer Not Found");
            }

            try
            {
                record.CName = value.CName;
                record.CAddress = value.CAddress;
                record.Phone = value.Phone;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record updated");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Update operation failed with exception {0}", e.Message);
            }
        }
        [Route("api/CustomerAPI/Delete/{id}")]
        // DELETE: api/CustomerAPI/Delete/1
        public HttpResponseMessage Delete(int id)
        {
            using (CustomersContext db = new CustomersContext())
            {
                var record = db.Customers.FirstOrDefault(c => c.CustomerID == id);

                if (record == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to find that Customer");
                }

                try
                {
                    db.Customers.Remove(record);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");

                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "DELETE operation failed with exception {0}", e.Message);
                }
            }
        }

    }
}
