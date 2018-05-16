using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using shop2.Models;
using PagedList;
using System.Data.SqlClient;

namespace shop2.Controllers
{
    public class CustomerController : Controller
    {
        //private shopdbEntities db = new shopdbEntities();
        private ICustomersContext db = new CustomersContext();

        public CustomerController() { }

        public CustomerController(ICustomersContext context)
        {
            db = context;
        }

        // GET: Customer
        //public ActionResult Index() //method before sorting/filtering implemented
        //{
        //    return View(db.Customers.ToList());
        //}
        //======sorting filtering======================================
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AddressSortParm = sortOrder == "Address" ? "address_desc" : "Address";
            //ViewBag.PhoneSortParm = sortOrder == "Phone" ? "phone_desc" : "Phone";

            if (searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var customers = from c in db.Customers
                            select c;
            //====searchinf stuff
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.CName.Contains(searchString));
            }
            //===================
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(x => x.CName);
                    break;
                case "Address":
                    customers = customers.OrderBy(s => s.CAddress);
                    break;
                case "address_desc":
                    customers = customers.OrderByDescending(s => s.CAddress);
                    break;
                //case "Phone":
                //    customers = customers.OrderBy(s => s.Phone);
                //    break;
                //case "phone_desc":
                //    customers = customers.OrderByDescending(s => s.Phone);
                //    break;
                default:
                    customers = customers.OrderBy(y => y.CName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        //==============================================
        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]      //raf: attribute helps prevent cross-site request forgery attacks.
        public ActionResult Create([Bind(Include = "CustomerID,CName,CAddress,Phone")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)     //raf: server-side validation
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CName,CAddress,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(customer).State = EntityState.Modified;
                db.MarkAsModified(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View(customer);
           
        }

        //This parameter is false when the HttpGet Delete method is called without a 
        //previous failure.When it is called by the HttpPost Delete method in response toentry
        //a database update error, the parameter is true and an error message is passed to the view.


        // GET: Customer/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //raf: Updating the Delete Page
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again and if the problem persists see your system administrator.";
            }
            //---------------------

            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {           //raf: delete operation catches any database update errors
                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
            //Closing Database Connections
        }
    }
}
