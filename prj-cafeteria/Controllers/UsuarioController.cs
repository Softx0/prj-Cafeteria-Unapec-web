using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prj_cafeteria.Models;
using prj_cafeteria.Utils;

namespace prj_cafeteria.Controllers
{
    public class UsuarioController : Controller
    {
        private CafeteriaUnapecEntities db = new CafeteriaUnapecEntities();
        private Validaciones validaciones = new Validaciones();

        // GET: Usuario
        public ActionResult Index(string Criterio = null)
        {
            var uSUARIO = db.USUARIO.Include(u => u.TIPOUSUARIO).Include(u => u.ESTADO1);
            return View(db.USUARIO.Where(p => Criterio == null ||
                                                p.NOMBRE.StartsWith(Criterio) ||
                                                p.CEDULA.StartsWith(Criterio) ||
                                                p.TIPOUSUARIO.DESCRIPCION.StartsWith(Criterio) ||
                                                p.LIMITECREDITO.ToString().StartsWith(Criterio)||
                                                p.ESTADO1.Estado1.StartsWith(Criterio))
                                                .ToList());
        }

        // GET: Usuario/Details/5
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

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION");
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,CEDULA,IDTIPOUSUARIO,LIMITECREDITO,FECHAREGISTRO,Estado")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                if (validaciones.IsValiCedula(uSUARIO.CEDULA))
                {
                    db.USUARIO.Add(uSUARIO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Cedula", "La Cedula es incorrecta.");
                }
            }

            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION", uSUARIO.IDTIPOUSUARIO);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", uSUARIO.Estado);
            return View(uSUARIO);
        }

        // GET: Usuario/Edit/5
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
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", uSUARIO.Estado);
            return View(uSUARIO);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,CEDULA,IDTIPOUSUARIO,LIMITECREDITO,FECHAREGISTRO,Estado")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTIPOUSUARIO = new SelectList(db.TIPOUSUARIO, "ID", "DESCRIPCION", uSUARIO.IDTIPOUSUARIO);
            ViewBag.Estado = new SelectList(db.ESTADO, "Id", "Estado1", uSUARIO.Estado);
            return View(uSUARIO);
        }

        // GET: Usuario/Delete/5
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

        // POST: Usuario/Delete/5
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
