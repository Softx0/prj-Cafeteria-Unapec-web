using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prj_cafeteria.Models;
using prj_cafeteria.Utils;

namespace prj_cafeteria.Controllers
{
    public class ProveedorController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();
        private Validaciones validaciones = new Validaciones();

        // GET: Proveedor
        public ActionResult Index(string Criterio = null)
        {
            var pROVEEDOR = db.PROVEEDOR.Include(p => p.ESTADO1);
            return View(db.PROVEEDOR.Where(p => Criterio == null ||
                                                p.NOMBRE.StartsWith(Criterio) ||
                                                p.RNC.StartsWith(Criterio) ||
                                                p.ESTADO1.Estado1.StartsWith(Criterio))
                                                .ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: Proveedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,RNC,FECHAREGISTRO,Estado")] PROVEEDOR pROVEEDOR)
        {
            if (ModelState.IsValid)
            {

                db.PROVEEDOR.Add(pROVEEDOR);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", pROVEEDOR.Estado);
            return View(pROVEEDOR);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", pROVEEDOR.Estado);
            return View(pROVEEDOR);
        }

        // POST: Proveedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,RNC,FECHAREGISTRO,Estado")] PROVEEDOR pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROVEEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", pROVEEDOR.Estado);
            return View(pROVEEDOR);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            db.PROVEEDOR.Remove(pROVEEDOR);
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
