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
    public class CafeteriaArticuloController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: CafeteriaArticulo
        public ActionResult Index()
        {
            var cAFETERIARTICULO = db.CAFETERIARTICULO.Include(c => c.Articulos).Include(c => c.CAFETERIA);
            return View(cAFETERIARTICULO.ToList());
        }

        // GET: CafeteriaArticulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIARTICULO cAFETERIARTICULO = db.CAFETERIARTICULO.Find(id);
            if (cAFETERIARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(cAFETERIARTICULO);
        }

        // GET: CafeteriaArticulo/Create
        public ActionResult Create()
        {
            ViewBag.IDARTICULO = new SelectList(db.Articulos, "ID", "DESCRIPCION");
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE");
            return View();
        }

        // POST: CafeteriaArticulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDARTICULO,IDCAFETERIA")] CAFETERIARTICULO cAFETERIARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.CAFETERIARTICULO.Add(cAFETERIARTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDARTICULO = new SelectList(db.Articulos, "ID", "DESCRIPCION", cAFETERIARTICULO.IDARTICULO);
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIARTICULO.IDCAFETERIA);
            return View(cAFETERIARTICULO);
        }

        // GET: CafeteriaArticulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIARTICULO cAFETERIARTICULO = db.CAFETERIARTICULO.Find(id);
            if (cAFETERIARTICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDARTICULO = new SelectList(db.Articulos, "ID", "DESCRIPCION", cAFETERIARTICULO.IDARTICULO);
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIARTICULO.IDCAFETERIA);
            return View(cAFETERIARTICULO);
        }

        // POST: CafeteriaArticulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDARTICULO,IDCAFETERIA")] CAFETERIARTICULO cAFETERIARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAFETERIARTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDARTICULO = new SelectList(db.Articulos, "ID", "DESCRIPCION", cAFETERIARTICULO.IDARTICULO);
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIARTICULO.IDCAFETERIA);
            return View(cAFETERIARTICULO);
        }

        // GET: CafeteriaArticulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAFETERIARTICULO cAFETERIARTICULO = db.CAFETERIARTICULO.Find(id);
            if (cAFETERIARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(cAFETERIARTICULO);
        }

        // POST: CafeteriaArticulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAFETERIARTICULO cAFETERIARTICULO = db.CAFETERIARTICULO.Find(id);
            db.CAFETERIARTICULO.Remove(cAFETERIARTICULO);
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
