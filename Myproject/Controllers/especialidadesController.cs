using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Myproject.Models;

namespace Myproject.Controllers
{
    public class especialidadesController : Controller
    {
        private projectEntities db = new projectEntities();

        // GET: especialidades
        public ActionResult Index()
        {
            return View(db.especialidades.ToList());
        }

        // GET: especialidades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidades especialidades = db.especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // GET: especialidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: especialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "especialidade")] especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.especialidades.Add(especialidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidades);
        }

        // GET: especialidades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidades especialidades = db.especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // POST: especialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "especialidade")] especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidades);
        }

        // GET: especialidades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            especialidades especialidades = db.especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // POST: especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            especialidades especialidades = db.especialidades.Find(id);
            db.especialidades.Remove(especialidades);
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
