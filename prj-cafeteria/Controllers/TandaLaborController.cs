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
    public class TandaLaborController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: TandaLabor
        public ActionResult Index()
        {
            var tANDALABOR = db.TANDALABOR.Include(t => t.ESTADO1);
            return View(tANDALABOR.ToList());
        }

        // GET: TandaLabor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TANDALABOR tANDALABOR = db.TANDALABOR.Find(id);
            if (tANDALABOR == null)
            {
                return HttpNotFound();
            }
            return View(tANDALABOR);
        }

        // GET: TandaLabor/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: TandaLabor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TANDA,Estado")] TANDALABOR tANDALABOR)
        {
            if (ModelState.IsValid)
            {
                db.TANDALABOR.Add(tANDALABOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", tANDALABOR.Estado);
            return View(tANDALABOR);
        }

        // GET: TandaLabor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TANDALABOR tANDALABOR = db.TANDALABOR.Find(id);
            if (tANDALABOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", tANDALABOR.Estado);
            return View(tANDALABOR);
        }

        // POST: TandaLabor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TANDA,Estado")] TANDALABOR tANDALABOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tANDALABOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", tANDALABOR.Estado);
            return View(tANDALABOR);
        }

        // GET: TandaLabor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TANDALABOR tANDALABOR = db.TANDALABOR.Find(id);
            if (tANDALABOR == null)
            {
                return HttpNotFound();
            }
            return View(tANDALABOR);
        }

        // POST: TandaLabor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TANDALABOR tANDALABOR = db.TANDALABOR.Find(id);
            db.TANDALABOR.Remove(tANDALABOR);
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
