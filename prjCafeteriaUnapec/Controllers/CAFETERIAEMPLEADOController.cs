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
    public class CAFETERIAEMPLEADOController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: CAFETERIAEMPLEADO
        public ActionResult Index()
        {
            var cAFETERIAEMPLEADO = db.CAFETERIAEMPLEADO.Include(c => c.CAFETERIA).Include(c => c.EMPLEADO);
            return View(cAFETERIAEMPLEADO.ToList());
        }

        // GET: CAFETERIAEMPLEADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIAEMPLEADO cAFETERIAEMPLEADO = db.CAFETERIAEMPLEADO.Find(id);
            if (cAFETERIAEMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(cAFETERIAEMPLEADO);
        }

        // GET: CAFETERIAEMPLEADO/Create
        public ActionResult Create()
        {
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE");
            ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "ID", "NOMBRE");
            return View();
        }

        // POST: CAFETERIAEMPLEADO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEMPLEADO,ID,IDCAFETERIA")] CAFETERIAEMPLEADO cAFETERIAEMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.CAFETERIAEMPLEADO.Add(cAFETERIAEMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIAEMPLEADO.IDCAFETERIA);
            ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "ID", "NOMBRE", cAFETERIAEMPLEADO.IDEMPLEADO);
            return View(cAFETERIAEMPLEADO);
        }

        // GET: CAFETERIAEMPLEADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIAEMPLEADO cAFETERIAEMPLEADO = db.CAFETERIAEMPLEADO.Find(id);
            if (cAFETERIAEMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIAEMPLEADO.IDCAFETERIA);
            ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "ID", "NOMBRE", cAFETERIAEMPLEADO.IDEMPLEADO);
            return View(cAFETERIAEMPLEADO);
        }

        // POST: CAFETERIAEMPLEADO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEMPLEADO,ID,IDCAFETERIA")] CAFETERIAEMPLEADO cAFETERIAEMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAFETERIAEMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIAEMPLEADO.IDCAFETERIA);
            ViewBag.IDEMPLEADO = new SelectList(db.EMPLEADO, "ID", "NOMBRE", cAFETERIAEMPLEADO.IDEMPLEADO);
            return View(cAFETERIAEMPLEADO);
        }

        // GET: CAFETERIAEMPLEADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIAEMPLEADO cAFETERIAEMPLEADO = db.CAFETERIAEMPLEADO.Find(id);
            if (cAFETERIAEMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(cAFETERIAEMPLEADO);
        }

        // POST: CAFETERIAEMPLEADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAFETERIAEMPLEADO cAFETERIAEMPLEADO = db.CAFETERIAEMPLEADO.Find(id);
            db.CAFETERIAEMPLEADO.Remove(cAFETERIAEMPLEADO);
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
