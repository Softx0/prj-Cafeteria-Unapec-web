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
    public class ArticulosController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: Articulos
        public ActionResult Index()
        {
            var articulos = db.Articulos.Include(a => a.MARCA).Include(a => a.PROVEEDOR).Include(a => a.ESTADO1);
            return View(articulos.ToList());
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE");
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "ID", "NOMBRE");
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,IDMARCA,IDPROVEEDOR,COSTO,EXISTENCIA,Estado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE", articulos.IDMARCA);
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "ID", "NOMBRE", articulos.IDPROVEEDOR);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", articulos.Estado);
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE", articulos.IDMARCA);
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "ID", "NOMBRE", articulos.IDPROVEEDOR);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", articulos.Estado);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,IDMARCA,IDPROVEEDOR,COSTO,EXISTENCIA,Estado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE", articulos.IDMARCA);
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "ID", "NOMBRE", articulos.IDPROVEEDOR);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", articulos.Estado);
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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
