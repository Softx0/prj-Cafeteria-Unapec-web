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
    public class USUARIOController : Controller
    {
        private CAFETERIAUNAPECEntities db = new CAFETERIAUNAPECEntities();

        // GET: USUARIO
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.TIPOUSUARIO);
            return View(uSUARIO.ToList());
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION");
            return View();
        }

        // POST: USUARIO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,CEDULA,IDTIPOUSUARIO,LIMITECREDITO,FECHAREGISTRO,ESTADO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION", uSUARIO.IDTIPOUSUARIO);
            return View(uSUARIO);
        }

        // GET: USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION", uSUARIO.IDTIPOUSUARIO);
            return View(uSUARIO);
        }

        // POST: USUARIO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,CEDULA,IDTIPOUSUARIO,LIMITECREDITO,FECHAREGISTRO,ESTADO")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION", uSUARIO.IDTIPOUSUARIO);
            return View(uSUARIO);
        }

        // GET: USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
