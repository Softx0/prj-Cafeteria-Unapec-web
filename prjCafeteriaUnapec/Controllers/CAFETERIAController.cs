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
    public class CAFETERIAController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: CAFETERIA
        public ActionResult Index()
        {
            var cAFETERIA = db.CAFETERIA.Include(c => c.CAMPUS);
            return View(cAFETERIA.ToList());
        }

        // GET: CAFETERIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIA cAFETERIA = db.CAFETERIA.Find(id);
            if (cAFETERIA == null)
            {
                return HttpNotFound();
            }
            return View(cAFETERIA);
        }

        // GET: CAFETERIA/Create
        public ActionResult Create()
        {
            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE");
            return View();
        }

        // POST: CAFETERIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,ENCARGADO,IDCAMPUS,ESTADO")] CAFETERIA cAFETERIA)
        {
            if (ModelState.IsValid)
            {
                db.CAFETERIA.Add(cAFETERIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE", cAFETERIA.IDCAMPUS);
            return View(cAFETERIA);
        }

        // GET: CAFETERIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIA cAFETERIA = db.CAFETERIA.Find(id);
            if (cAFETERIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE", cAFETERIA.IDCAMPUS);
            return View(cAFETERIA);
        }

        // POST: CAFETERIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,ENCARGADO,IDCAMPUS,ESTADO")] CAFETERIA cAFETERIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAFETERIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE", cAFETERIA.IDCAMPUS);
            return View(cAFETERIA);
        }

        // GET: CAFETERIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIA cAFETERIA = db.CAFETERIA.Find(id);
            if (cAFETERIA == null)
            {
                return HttpNotFound();
            }
            return View(cAFETERIA);
        }

        // POST: CAFETERIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAFETERIA cAFETERIA = db.CAFETERIA.Find(id);
            db.CAFETERIA.Remove(cAFETERIA);
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
