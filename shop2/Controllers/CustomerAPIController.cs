﻿using System;
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
        public string Get()
        {
            //return db.Customers.ToList().OrderByDescending(x => x.CName);
            return "xxx";
        }

        // GET: api/CustomerAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CustomerAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerAPI/5
        public void Delete(int id)
        {
        }
    }
}