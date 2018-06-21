using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICOnboardingP1.Models;
using ICOnboardingP1.ViewModels;

namespace ICOnboardingP1.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sales
        public ViewResult Index()
        {
            var productSolds = db.ProductSolds.Include(c => c.Customer).Include(p => p.Product).Include(st => st.Store).ToList();
            return View(productSolds);
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductSolds.Include(c => c.Customer).Include(p => p.Product).Include(st => st.Store).SingleOrDefault(ps => ps.Id == id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            return View(productSold);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {

            var customers = db.Customers.ToList();
            var products = db.Products.ToList();
            var stores = db.Stores.ToList();

            var viewModel = new SalesRecordViewModel
            {
                Customers = customers,
                Products = products,
                Stores = stores,
            };

            return View(viewModel);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSold productSold)
        {
            
            
                db.ProductSolds.Add(productSold);
                db.SaveChanges();
            

            return RedirectToAction("Index");
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductSolds.Include(c => c.Customer).Include(p => p.Product).Include(st => st.Store).SingleOrDefault(ps => ps.Id == id);
            if (productSold == null)
            {
                return HttpNotFound();
            }

            var viewModel = new SalesRecordViewModel()
            {
                ProductSold = productSold,
                Customers = db.Customers.ToList(),
                Products = db.Products.ToList(),
                Stores = db.Stores.ToList()

            };

            return View(viewModel);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSold productSold)
        {
            var productSoldInDb = db.ProductSolds.Include(c => c.Customer).Include(p => p.Product).Include(st => st.Store).SingleOrDefault(ps => ps.Id == productSold.Id);

            productSoldInDb.CustomerId = productSold.CustomerId;
            productSoldInDb.ProductId = productSold.ProductId;
            productSoldInDb.StoreId = productSold.StoreId;
            productSoldInDb.DateSold = productSold.DateSold;

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductSolds.Include(c => c.Customer).Include(p => p.Product).Include(st => st.Store).SingleOrDefault(ps => ps.Id == id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            return View(productSold);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSold productSold = db.ProductSolds.Find(id);
            db.ProductSolds.Remove(productSold);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
