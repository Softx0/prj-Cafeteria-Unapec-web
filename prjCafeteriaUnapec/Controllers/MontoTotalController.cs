using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjCafeteriaUnapec;

namespace prjCafeteriaUnapec.Controllers
{
    public class MontoTotalController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: MontoTotal
        public ActionResult Index()
        {
            return View(db.MontoTotal.ToList());
        }

        // GET: MontoTotal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MontoTotal montoTotal = db.MontoTotal.Find(id);
            if (montoTotal == null)
            {
                return HttpNotFound();
            }
            return View(montoTotal);
        }

        // GET: MontoTotal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MontoTotal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idfactura,MONTOTOTAL1")] MontoTotal montoTotal)
        {
            if (ModelState.IsValid)
            {
                db.MontoTotal.Add(montoTotal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(montoTotal);
        }

        // GET: MontoTotal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MontoTotal montoTotal = db.MontoTotal.Find(id);
            if (montoTotal == null)
            {
                return HttpNotFound();
            }
            return View(montoTotal);
        }

        // POST: MontoTotal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idfactura,MONTOTOTAL1")] MontoTotal montoTotal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(montoTotal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(montoTotal);
        }

        // GET: MontoTotal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MontoTotal montoTotal = db.MontoTotal.Find(id);
            if (montoTotal == null)
            {
                return HttpNotFound();
            }
            return View(montoTotal);
        }

        // POST: MontoTotal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MontoTotal montoTotal = db.MontoTotal.Find(id);
            db.MontoTotal.Remove(montoTotal);
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
