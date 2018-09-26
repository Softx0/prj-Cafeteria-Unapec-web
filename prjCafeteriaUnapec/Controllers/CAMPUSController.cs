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
    public class CAMPUSController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: CAMPUS
        public ActionResult Index()
        {
            return View(db.CAMPUS.ToList());
        }

        // GET: CAMPUS/Details/5
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

        // GET: CAMPUS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CAMPUS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,ESTADO")] CAMPUS cAMPUS)
        {
            if (ModelState.IsValid)
            {
                db.CAMPUS.Add(cAMPUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAMPUS);
        }

        // GET: CAMPUS/Edit/5
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
            return View(cAMPUS);
        }

        // POST: CAMPUS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,ESTADO")] CAMPUS cAMPUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMPUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAMPUS);
        }

        // GET: CAMPUS/Delete/5
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

        // POST: CAMPUS/Delete/5
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
