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
    public class TIPOUSUARIOController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: TIPOUSUARIO
        public ActionResult Index()
        {
            return View(db.TIPOUSUARIO.ToList());
        }

        // GET: TIPOUSUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOUSUARIO tIPOUSUARIO = db.TIPOUSUARIO.Find(id);
            if (tIPOUSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOUSUARIO);
        }

        // GET: TIPOUSUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOUSUARIO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,ESTADO")] TIPOUSUARIO tIPOUSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOUSUARIO.Add(tIPOUSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOUSUARIO);
        }

        // GET: TIPOUSUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOUSUARIO tIPOUSUARIO = db.TIPOUSUARIO.Find(id);
            if (tIPOUSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOUSUARIO);
        }

        // POST: TIPOUSUARIO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,ESTADO")] TIPOUSUARIO tIPOUSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOUSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOUSUARIO);
        }

        // GET: TIPOUSUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOUSUARIO tIPOUSUARIO = db.TIPOUSUARIO.Find(id);
            if (tIPOUSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOUSUARIO);
        }

        // POST: TIPOUSUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOUSUARIO tIPOUSUARIO = db.TIPOUSUARIO.Find(id);
            db.TIPOUSUARIO.Remove(tIPOUSUARIO);
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
