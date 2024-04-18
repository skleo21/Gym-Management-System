using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Myproject.Models;
using PagedList;

namespace Myproject.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]

    public class TrainersController : Controller
    {
        private projectEntities db = new projectEntities();

        // GET: Trainers
        public ActionResult ListarTrainer(String msg, string ordem, int? page)
        {
           

            ViewBag.msg = msg;
            int pagesize = 5;
            int pagina = page ?? 1;
            using (projectEntities db = new projectEntities())
            {
                if (String.IsNullOrEmpty(ordem)) ordem = "nomedesc";
                ViewBag.nome = (ordem == "nomedesc") ? "nomeasc" : "nomedesc";
                ViewBag.ordem = ordem;
                List<trainers> trainers = db.trainers.ToList();

                switch (ordem)
                {
                    case "nomeasc":
                        trainers = trainers.OrderBy(x => x.ptrainer).ToList();
                        break;
                    case "nomedesc":
                        trainers = trainers.OrderByDescending(x => x.ptrainer).ToList();
                        break;
                    default:
                        trainers = trainers.OrderBy(x => x.idpt).ToList();
                        break;

                }
                return View(trainers.ToPagedList(pagina, pagesize));

            }

            {
                var trainers = db.trainers.Include(p => p.especialidades);
                //return View(trainers.ToList());
                return View(trainers.ToPagedList(pagina, pagesize));
            }


        }

        //// GET: Trainers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    trainers trainers = db.trainers.Find(id);
        //    if (trainers == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trainers);
        //}

        // GET: Trainers/Create
        [HttpPost]
        public ActionResult AddTrainer(trainers novo, HttpPostedFileBase fich)
        {
            {
                ViewBag.especialidade = new SelectList(db.especialidades, "especialidade", "especialidade");
                return View();
            }

            {
                try
                {

                    using (projectEntities db = new projectEntities())
                    {
                        db.trainers.Add(novo);
                        db.SaveChanges();
                        //if (fich != null && fich.ContentLength > 0 && fich.ContentType.Contains("image"))
                        //{
                        //    String path = "~/fotos/" + novo.idpt.ToString() + System.IO.Path.GetExtension(fich.FileName);
                        //    novo.ptrainerfoto = path;
                        //    fich.SaveAs(Server.MapPath(path));
                        //    db.SaveChanges();
                        //}
                        return RedirectToAction("ListarTrainers", "Trainers", new { msg = "Inserido com Sucesso" });
                    }

                }
                catch (Exception erro)
                {

                    return RedirectToAction("ListarTraines", "Trainers", new { msg = erro.Message });
                }
            }



        }



        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpt,ptrainer,especialidade,xp,idade,ptrainerfoto,phora")] trainers trainers)
        {
            if (ModelState.IsValid)
            {
                db.trainers.Add(trainers);
                db.SaveChanges();
                return RedirectToAction("ListarTrainer");
            }

            ViewBag.especialidade = new SelectList(db.especialidades, "especialidade", "especialidade", trainers.especialidade);
            return View(trainers);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainers trainers = db.trainers.Find(id);
            if (trainers == null)
            {
                return HttpNotFound();
            }
            ViewBag.especialidade = new SelectList(db.especialidades, "especialidade", "especialidade", trainers.especialidade);
            return View(trainers);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpt,ptrainer,especialidade,xp,idade,ptrainerfoto,phora")] trainers trainers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListarTrainer");
            }
            ViewBag.especialidade = new SelectList(db.especialidades, "especialidade", "especialidade", trainers.especialidade);
            return View(trainers);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainers trainers = db.trainers.Find(id);
            if (trainers == null)
            {
                return HttpNotFound();
            }
            return View(trainers);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainers trainers = db.trainers.Find(id);
            db.trainers.Remove(trainers);
            db.SaveChanges();
            return RedirectToAction("ListarTrainer");
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
