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
    public class DetalleFactura_ViewController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: DetalleFactura_View
        public ActionResult Index()
        {
            return View(db.DetalleFactura_View.ToList());
        }

        // GET: DetalleFactura_View/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura_View detalleFactura_View = db.DetalleFactura_View.Find(id);
            if (detalleFactura_View == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura_View);
        }

        // GET: DetalleFactura_View/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleFactura_View/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UNIDADES,IDFACTURA,DESCRIPCION,COSTO")] DetalleFactura_View detalleFactura_View)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFactura_View.Add(detalleFactura_View);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalleFactura_View);
        }

        // GET: DetalleFactura_View/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura_View detalleFactura_View = db.DetalleFactura_View.Find(id);
            if (detalleFactura_View == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura_View);
        }

        // POST: DetalleFactura_View/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UNIDADES,IDFACTURA,DESCRIPCION,COSTO")] DetalleFactura_View detalleFactura_View)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFactura_View).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalleFactura_View);
        }

        // GET: DetalleFactura_View/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura_View detalleFactura_View = db.DetalleFactura_View.Find(id);
            if (detalleFactura_View == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura_View);
        }

        // POST: DetalleFactura_View/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFactura_View detalleFactura_View = db.DetalleFactura_View.Find(id);
            db.DetalleFactura_View.Remove(detalleFactura_View);
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
