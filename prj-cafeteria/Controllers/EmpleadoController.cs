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
    public class EmpleadoController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();
        private Validaciones validaciones = new Validaciones();

        // GET: Empleado
        public ActionResult Index()
        {
            var eMPLEADO = db.EMPLEADO.Include(e => e.TANDALABOR).Include(e => e.ESTADO1);
            return View(eMPLEADO.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.IDTANDALABOR = new SelectList(db.TANDALABOR, "ID", "TANDA");
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDTANDALABOR,NOMBRE,CEDULA,COMISION,FECHAREGISTRO,Estado")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                if (validaciones.valiCedula(eMPLEADO.CEDULA))
                {
                    db.EMPLEADO.Add(eMPLEADO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Cedula", "La Cedula es incorrecta.");
                }
            }

            
            ViewBag.IDTANDALABOR = new SelectList(db.TANDALABOR, "ID", "TANDA", eMPLEADO.IDTANDALABOR);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", eMPLEADO.Estado);
            return View(eMPLEADO);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTANDALABOR = new SelectList(db.TANDALABOR, "ID", "TANDA", eMPLEADO.IDTANDALABOR);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", eMPLEADO.Estado);
            return View(eMPLEADO);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDTANDALABOR,NOMBRE,CEDULA,COMISION,FECHAREGISTRO,Estado")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTANDALABOR = new SelectList(db.TANDALABOR, "ID", "TANDA", eMPLEADO.IDTANDALABOR);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", eMPLEADO.Estado);
            return View(eMPLEADO);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            db.EMPLEADO.Remove(eMPLEADO);
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
