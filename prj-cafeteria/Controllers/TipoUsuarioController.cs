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
    public class TipoUsuarioController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();

        // GET: TipoUsuario
        public ActionResult Index()
        {
            var tIPOUSUARIO = db.TIPOUSUARIO.Include(t => t.ESTADO1);
            return View(tIPOUSUARIO.ToList());
        }

        // GET: TipoUsuario/Details/5
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

        // GET: TipoUsuario/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: TipoUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,Estado")] TIPOUSUARIO tIPOUSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPOUSUARIO.Add(tIPOUSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", tIPOUSUARIO.Estado);
            return View(tIPOUSUARIO);
        }

        // GET: TipoUsuario/Edit/5
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
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", tIPOUSUARIO.Estado);
            return View(tIPOUSUARIO);
        }

        // POST: TipoUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,Estado")] TIPOUSUARIO tIPOUSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOUSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", tIPOUSUARIO.Estado);
            return View(tIPOUSUARIO);
        }

        // GET: TipoUsuario/Delete/5
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

        // POST: TipoUsuario/Delete/5
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
