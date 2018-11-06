using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prj_cafeteria.Models;

namespace prj_cafeteria.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: DetalleFacturas
        public ActionResult Index()
        {
            var detalleFactura = db.DetalleFactura.Include(d => d.Articulos).Include(d => d.Factura);
            return View(detalleFactura.ToList());
        }

        // GET: DetalleFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.Articulos, "ID", "DESCRIPCION");
            ViewBag.idFactura = new SelectList(db.Factura, "ID", "ID");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalleFactura,idArticulo,idFactura,unidades")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFactura.Add(detalleFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.Articulos, "ID", "DESCRIPCION", detalleFactura.idArticulo);
            ViewBag.idFactura = new SelectList(db.Factura, "ID", "ID", detalleFactura.idFactura);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.Articulos, "ID", "DESCRIPCION", detalleFactura.idArticulo);
            ViewBag.idFactura = new SelectList(db.Factura, "ID", "fecha", detalleFactura.idFactura);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalleFactura,idArticulo,idFactura,unidades")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.Articulos, "ID", "DESCRIPCION", detalleFactura.idArticulo);
            ViewBag.idFactura = new SelectList(db.Factura, "ID", "fecha", detalleFactura.idFactura);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            db.DetalleFactura.Remove(detalleFactura);
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
