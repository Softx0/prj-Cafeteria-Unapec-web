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
    public class ARTICULOController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: ARTICULO
        public ActionResult Index()
        {
            var aRTICULO = db.ARTICULO.Include(a => a.MARCA);
            return View(aRTICULO.ToList());
        }

        // GET: ARTICULO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // GET: ARTICULO/Create
        public ActionResult Create()
        {
            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE");
            return View();
        }

        // POST: ARTICULO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,IDMARCA,IDPROVEEDOR,COSTO,EXISTENCIA,ESTADO")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.ARTICULO.Add(aRTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE", aRTICULO.IDMARCA);
            return View(aRTICULO);
        }

        // GET: ARTICULO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE", aRTICULO.IDMARCA);
            return View(aRTICULO);
        }

        // POST: ARTICULO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,IDMARCA,IDPROVEEDOR,COSTO,EXISTENCIA,ESTADO")] ARTICULO aRTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMARCA = new SelectList(db.MARCA, "ID", "NOMBRE", aRTICULO.IDMARCA);
            return View(aRTICULO);
        }

        // GET: ARTICULO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            if (aRTICULO == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULO);
        }

        // POST: ARTICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICULO aRTICULO = db.ARTICULO.Find(id);
            db.ARTICULO.Remove(aRTICULO);
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
