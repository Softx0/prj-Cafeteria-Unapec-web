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
    public class MARCAController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: MARCA
        public ActionResult Index()
        {
            return View(db.MARCA.ToList());
        }

        // GET: MARCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // GET: MARCA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MARCA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,ESTADO")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.MARCA.Add(mARCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mARCA);
        }

        // GET: MARCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: MARCA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,ESTADO")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mARCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mARCA);
        }

        // GET: MARCA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: MARCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MARCA mARCA = db.MARCA.Find(id);
            db.MARCA.Remove(mARCA);
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
