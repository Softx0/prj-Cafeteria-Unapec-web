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
    public class CafeteriaController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: Cafeteria
        public ActionResult Index()
        {
            var cAFETERIA = db.CAFETERIA.Include(c => c.CAMPUS).Include(c => c.ESTADO1);
            return View(cAFETERIA.ToList());
        }

        // GET: Cafeteria/Details/5
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

        // GET: Cafeteria/Create
        public ActionResult Create()
        {
            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE");
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: Cafeteria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,ENCARGADO,IDCAMPUS,Estado")] CAFETERIA cAFETERIA)
        {
            if (ModelState.IsValid)
            {
                db.CAFETERIA.Add(cAFETERIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE", cAFETERIA.IDCAMPUS);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", cAFETERIA.Estado);
            return View(cAFETERIA);
        }

        // GET: Cafeteria/Edit/5
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
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", cAFETERIA.Estado);
            return View(cAFETERIA);
        }

        // POST: Cafeteria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,ENCARGADO,IDCAMPUS,Estado")] CAFETERIA cAFETERIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAFETERIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCAMPUS = new SelectList(db.CAMPUS, "ID", "NOMBRE", cAFETERIA.IDCAMPUS);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", cAFETERIA.Estado);
            return View(cAFETERIA);
        }

        // GET: Cafeteria/Delete/5
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

        // POST: Cafeteria/Delete/5
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
