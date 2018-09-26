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
    public class FACTURACION_ARTICULOSController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: FACTURACION_ARTICULOS
        public ActionResult Index()
        {
            var fACTURACION_ARTICULOS = db.FACTURACION_ARTICULOS.Include(f => f.ARTICULO).Include(f => f.EMPLEADO).Include(f => f.USUARIO);
            return View(fACTURACION_ARTICULOS.ToList());
        }

        // GET: FACTURACION_ARTICULOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURACION_ARTICULOS fACTURACION_ARTICULOS = db.FACTURACION_ARTICULOS.Find(id);
            if (fACTURACION_ARTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(fACTURACION_ARTICULOS);
        }

        // GET: FACTURACION_ARTICULOS/Create
        public ActionResult Create()
        {
            ViewBag.IdArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION");
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE");
            ViewBag.IdUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE");
            return View();
        }

        // POST: FACTURACION_ARTICULOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoFactura,Unidades,IdEmpleado,IdArticulo,IdUsuario,FechaVenta,MontoArticulo,Comentario,Estado")] FACTURACION_ARTICULOS fACTURACION_ARTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.FACTURACION_ARTICULOS.Add(fACTURACION_ARTICULOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", fACTURACION_ARTICULOS.IdArticulo);
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", fACTURACION_ARTICULOS.IdEmpleado);
            ViewBag.IdUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", fACTURACION_ARTICULOS.IdUsuario);
            return View(fACTURACION_ARTICULOS);
        }

        // GET: FACTURACION_ARTICULOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURACION_ARTICULOS fACTURACION_ARTICULOS = db.FACTURACION_ARTICULOS.Find(id);
            if (fACTURACION_ARTICULOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", fACTURACION_ARTICULOS.IdArticulo);
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", fACTURACION_ARTICULOS.IdEmpleado);
            ViewBag.IdUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", fACTURACION_ARTICULOS.IdUsuario);
            return View(fACTURACION_ARTICULOS);
        }

        // POST: FACTURACION_ARTICULOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoFactura,Unidades,IdEmpleado,IdArticulo,IdUsuario,FechaVenta,MontoArticulo,Comentario,Estado")] FACTURACION_ARTICULOS fACTURACION_ARTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURACION_ARTICULOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArticulo = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", fACTURACION_ARTICULOS.IdArticulo);
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADO, "ID", "NOMBRE", fACTURACION_ARTICULOS.IdEmpleado);
            ViewBag.IdUsuario = new SelectList(db.USUARIO, "ID", "NOMBRE", fACTURACION_ARTICULOS.IdUsuario);
            return View(fACTURACION_ARTICULOS);
        }

        // GET: FACTURACION_ARTICULOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURACION_ARTICULOS fACTURACION_ARTICULOS = db.FACTURACION_ARTICULOS.Find(id);
            if (fACTURACION_ARTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(fACTURACION_ARTICULOS);
        }

        // POST: FACTURACION_ARTICULOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACTURACION_ARTICULOS fACTURACION_ARTICULOS = db.FACTURACION_ARTICULOS.Find(id);
            db.FACTURACION_ARTICULOS.Remove(fACTURACION_ARTICULOS);
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
