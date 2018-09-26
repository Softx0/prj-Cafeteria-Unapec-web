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
    public class FACTURAController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: FACTURA
        public ActionResult Index()
        {
            var factura = db.factura.Include(f => f.CAFETERIA).Include(f => f.EMPLEADO).Include(f => f.USUARIO);
            return View(factura.ToList());
        }

        // GET: FACTURA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: FACTURA/Create
        public ActionResult Create()
        {
            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE");
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE");
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE");
            return View();
        }

        // POST: FACTURA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFactura,fecha,modoPago,idUsuario,idEmpleado,montoTotal,idCafeteria")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE", factura.idCafeteria);
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", factura.idEmpleado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", factura.idUsuario);
            return View(factura);
        }

        // GET: FACTURA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCafeteria = new SelectList(db.CAFETERIA, "ID", "NOMBRE", factura.idCafeteria);
            ViewBag.idEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", factura.idEmpleado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", factura.idUsuario);
            return View(factura);
        }

        // POST: FACTURA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFactura,fecha,modoPago,idUsuario,idEmpleado,montoTotal,idCafeteria")] factura factura)
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

        // GET: FACTURA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: FACTURA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura factura = db.factura.Find(id);
            db.factura.Remove(factura);
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
