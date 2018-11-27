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
    public class FacturaController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: Factura
        public ActionResult Index(string Criterio = null)
        {
            var factura = db.Factura.Include(f => f.CAFETERIA).Include(f => f.EMPLEADO).Include(f => f.USUARIO);
            return View(db.Factura.Where(p => Criterio == null ||
                                                p.montoTotal.ToString().StartsWith(Criterio) ||
                                                p.modoPago.StartsWith(Criterio) ||
                                                p.USUARIO.NOMBRE.StartsWith(Criterio) ||
                                                p.EMPLEADO.NOMBRE.StartsWith(Criterio) ||
                                                p.CAFETERIA.NOMBRE.StartsWith(Criterio) ||
                                                p.fecha.StartsWith(Criterio)
                                                )
                                                .ToList());
        }

        // GET: Factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE");
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE");
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE");
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,fecha,modoPago,montoTotal,idUsuario,idEmpleado,idCafeteria")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE", factura.idCafeteria);
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", factura.idEmpleado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", factura.idUsuario);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE", factura.idCafeteria);
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", factura.idEmpleado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", factura.idUsuario);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,fecha,modoPago,montoTotal,idUsuario,idEmpleado,idCafeteria")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE", factura.idCafeteria);
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", factura.idEmpleado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", factura.idUsuario);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
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
