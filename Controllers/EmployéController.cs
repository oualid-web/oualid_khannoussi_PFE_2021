using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gestion_riad_projet_fin_etude.Models;

namespace gestion_riad_projet_fin_etude.Controllers
{
    public class EmployéController : Controller
    {
        private Gestion_riad2Entities1 db = new Gestion_riad2Entities1();

        // GET: Employé
        public ActionResult Index()
        {
            var employé = db.Employé.Include(e => e.Gerant);
            return View(employé.ToList());
        }

        // GET: Employé/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employé employé = db.Employé.Find(id);
            if (employé == null)
            {
                return HttpNotFound();
            }
            return View(employé);
        }

        // GET: Employé/Create
        public ActionResult Create()
        {
            ViewBag.Num_gerant = new SelectList(db.Gerant, "Num_gerant", "Num_gerant");
            return View();
        }

        // POST: Employé/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_empl,Nom_empl,Prénom_empl,télé_empl,repos,dat_embouchement,Num_gerant")] Employé employé)
        {
            if (ModelState.IsValid)
            {
                db.Employé.Add(employé);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_gerant = new SelectList(db.Gerant, "Num_gerant", "Nnm_gerant", employé.Num_gerant);
            return View(employé);
        }

        // GET: Employé/Edit/5
        public ActionResult Edit(string id)
        {
            //Book bk = Books.Single(b => b.id == id);
            //return View(bk);
            Employé employé = db.Employé.Find(id);
            return View (employé);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Employé employé = db.Employé.Find(id);
            //if (employé == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Num_gerant = new SelectList(db.Gerant, "Num_gerant", "Nom_gerant", employé.Num_gerant);
            //return View(employé);
        }

        // POST: Employé/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Employé em )
        {
            try
            {
                // TODO: Add update logic here
                Employé old_empl = db.Employé.Find(id);

                old_empl.Nom_empl = em.Nom_empl ;
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult Edit([Bind(Include = "Num_empl,Nom_empl,Prénom_empl,télé_empl,repos,dat_embouchement,Num_gerant")] Employé employé)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employé).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Num_gerant = new SelectList(db.Gerant, "Num_gerant", "Nom_gerant", employé.Num_gerant);
        //    return View(employé);
        //}

        // GET: Employé/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employé employé = db.Employé.Find(id);
            if (employé == null)
            {
                return HttpNotFound();
            }
            return View(employé);
        }

        // POST: Employé/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employé employé = db.Employé.Find(id);
            db.Employé.Remove(employé);
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
