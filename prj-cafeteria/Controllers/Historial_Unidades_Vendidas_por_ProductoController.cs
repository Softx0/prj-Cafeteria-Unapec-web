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
    public class Historial_Unidades_Vendidas_por_ProductoController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: Historial_Unidades_Vendidas_por_Producto
        public ActionResult Index(string Criterio = null)
        {
            return View(db.Historial_Unidades_Vendidas_por_Producto.Where(p => Criterio == null ||
                                                p.Total.ToString().StartsWith(Criterio) ||
                                                p.DESCRIPCION.StartsWith(Criterio))
                                                .ToList());
        }

        // GET: Historial_Unidades_Vendidas_por_Producto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial_Unidades_Vendidas_por_Producto historial_Unidades_Vendidas_por_Producto = db.Historial_Unidades_Vendidas_por_Producto.Find(id);
            if (historial_Unidades_Vendidas_por_Producto == null)
            {
                return HttpNotFound();
            }
            return View(historial_Unidades_Vendidas_por_Producto);
        }

        // GET: Historial_Unidades_Vendidas_por_Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historial_Unidades_Vendidas_por_Producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Total,DESCRIPCION")] Historial_Unidades_Vendidas_por_Producto historial_Unidades_Vendidas_por_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Historial_Unidades_Vendidas_por_Producto.Add(historial_Unidades_Vendidas_por_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historial_Unidades_Vendidas_por_Producto);
        }

        // GET: Historial_Unidades_Vendidas_por_Producto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial_Unidades_Vendidas_por_Producto historial_Unidades_Vendidas_por_Producto = db.Historial_Unidades_Vendidas_por_Producto.Find(id);
            if (historial_Unidades_Vendidas_por_Producto == null)
            {
                return HttpNotFound();
            }
            return View(historial_Unidades_Vendidas_por_Producto);
        }

        // POST: Historial_Unidades_Vendidas_por_Producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Total,DESCRIPCION")] Historial_Unidades_Vendidas_por_Producto historial_Unidades_Vendidas_por_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial_Unidades_Vendidas_por_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historial_Unidades_Vendidas_por_Producto);
        }

        // GET: Historial_Unidades_Vendidas_por_Producto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial_Unidades_Vendidas_por_Producto historial_Unidades_Vendidas_por_Producto = db.Historial_Unidades_Vendidas_por_Producto.Find(id);
            if (historial_Unidades_Vendidas_por_Producto == null)
            {
                return HttpNotFound();
            }
            return View(historial_Unidades_Vendidas_por_Producto);
        }

        // POST: Historial_Unidades_Vendidas_por_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Historial_Unidades_Vendidas_por_Producto historial_Unidades_Vendidas_por_Producto = db.Historial_Unidades_Vendidas_por_Producto.Find(id);
            db.Historial_Unidades_Vendidas_por_Producto.Remove(historial_Unidades_Vendidas_por_Producto);
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
