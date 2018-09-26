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
    public class DetalleFacturaController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: DetalleFactura
        public ActionResult Index()
        {
            var detallefactura = db.detallefactura.Include(d => d.ARTICULO).Include(d => d.factura);
            return View(detallefactura.ToList());
        }

        // GET: DetalleFactura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallefactura detallefactura = db.detallefactura.Find(id);
            if (detallefactura == null)
            {
                return HttpNotFound();
            }
            return View(detallefactura);
        }

        // GET: DetalleFactura/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION");
            ViewBag.idFactura = new SelectList(db.factura, "idFactura", "fecha");
            return View();
        }

        // POST: DetalleFactura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalleFactura,idArticulo,idFactura,unidades")] detallefactura detallefactura)
        {
            if (ModelState.IsValid)
            {
                db.detallefactura.Add(detallefactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", detallefactura.idArticulo);
            ViewBag.idFactura = new SelectList(db.factura, "idFactura", "fecha", detallefactura.idFactura);
            return View(detallefactura);
        }

        // GET: DetalleFactura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallefactura detallefactura = db.detallefactura.Find(id);
            if (detallefactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", detallefactura.idArticulo);
            ViewBag.idFactura = new SelectList(db.factura, "idFactura", "fecha", detallefactura.idFactura);
            return View(detallefactura);
        }

        // POST: DetalleFactura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalleFactura,idArticulo,idFactura,unidades")] detallefactura detallefactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallefactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", detallefactura.idArticulo);
            ViewBag.idFactura = new SelectList(db.factura, "idFactura", "fecha", detallefactura.idFactura);
            return View(detallefactura);
        }

        // GET: DetalleFactura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallefactura detallefactura = db.detallefactura.Find(id);
            if (detallefactura == null)
            {
                return HttpNotFound();
            }
            return View(detallefactura);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detallefactura detallefactura = db.detallefactura.Find(id);
            db.detallefactura.Remove(detallefactura);
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
