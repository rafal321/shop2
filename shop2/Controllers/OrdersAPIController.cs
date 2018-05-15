using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shop2.Controllers
{
    public class OrdersAPIController : ApiController
    {
        // GET: api/OrdersAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrdersAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrdersAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrdersAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrdersAPI/5
        public void Delete(int id)
        {
        }
    }
}
