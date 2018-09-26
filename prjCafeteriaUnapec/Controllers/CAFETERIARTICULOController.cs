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
    public class CAFETERIARTICULOController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: CAFETERIARTICULO
        public ActionResult Index()
        {
            var cAFETERIARTICULO = db.CAFETERIARTICULO.Include(c => c.ARTICULO).Include(c => c.CAFETERIA);
            return View(cAFETERIARTICULO.ToList());
        }

        // GET: CAFETERIARTICULO/Details/5
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

        // GET: CAFETERIARTICULO/Create
        public ActionResult Create()
        {
            ViewBag.IDARTICULO = new SelectList(db.ARTICULO, "ID", "DESCRIPCION");
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE");
            return View();
        }

        // POST: CAFETERIARTICULO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDARTICULO,IDCAFETERIA,ID")] CAFETERIARTICULO cAFETERIARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.CAFETERIARTICULO.Add(cAFETERIARTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDARTICULO = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", cAFETERIARTICULO.IDARTICULO);
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIARTICULO.IDCAFETERIA);
            return View(cAFETERIARTICULO);
        }

        // GET: CAFETERIARTICULO/Edit/5
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
            ViewBag.IDARTICULO = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", cAFETERIARTICULO.IDARTICULO);
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIARTICULO.IDCAFETERIA);
            return View(cAFETERIARTICULO);
        }

        // POST: CAFETERIARTICULO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDARTICULO,IDCAFETERIA,ID")] CAFETERIARTICULO cAFETERIARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAFETERIARTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDARTICULO = new SelectList(db.ARTICULO, "ID", "DESCRIPCION", cAFETERIARTICULO.IDARTICULO);
            ViewBag.IDCAFETERIA = new SelectList(db.CAFETERIA, "ID", "NOMBRE", cAFETERIARTICULO.IDCAFETERIA);
            return View(cAFETERIARTICULO);
        }

        // GET: CAFETERIARTICULO/Delete/5
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

        // POST: CAFETERIARTICULO/Delete/5
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
