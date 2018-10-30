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
    public class CampusController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: Campus
        public ActionResult Index()
        {
            var cAMPUS = db.CAMPUS.Include(c => c.ESTADO1);
            return View(cAMPUS.ToList());
        }

        // GET: Campus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPUS cAMPUS = db.CAMPUS.Find(id);
            if (cAMPUS == null)
            {
                return HttpNotFound();
            }
            return View(cAMPUS);
        }

        // GET: Campus/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,Estado")] CAMPUS cAMPUS)
        {
            if (ModelState.IsValid)
            {
                db.CAMPUS.Add(cAMPUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", cAMPUS.Estado);
            return View(cAMPUS);
        }

        // GET: Campus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPUS cAMPUS = db.CAMPUS.Find(id);
            if (cAMPUS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", cAMPUS.Estado);
            return View(cAMPUS);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,Estado")] CAMPUS cAMPUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMPUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", cAMPUS.Estado);
            return View(cAMPUS);
        }

        // GET: Campus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPUS cAMPUS = db.CAMPUS.Find(id);
            if (cAMPUS == null)
            {
                return HttpNotFound();
            }
            return View(cAMPUS);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAMPUS cAMPUS = db.CAMPUS.Find(id);
            db.CAMPUS.Remove(cAMPUS);
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
