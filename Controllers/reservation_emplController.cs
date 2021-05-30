﻿using System;
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
    public class reservation_emplController : Controller
    {
        private Gestion_riad2Entities1 db = new Gestion_riad2Entities1();

        // GET: reservation_empl
        public ActionResult Index()
        {
            var reservation = db.reservation.Include(r => r.Client).Include(r => r.Employé);
            return View(reservation.ToList());
        }

        // GET: reservation_empl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: reservation_empl/Create
        public ActionResult Create()
        {
            ViewBag.Num_clt = new SelectList(db.Client, "Num_clt", "Num_clt");
            ViewBag.Num_empl = new SelectList(db.Employé, "Num_empl", "Nom_empl");
            return View();
        }

        // POST: reservation_empl/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_res,Dat_res,Typpe_res,Duré_res,Nb_Adult,Nb_Enfant,Num_clt,Num_empl,Prix_res")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservation.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_clt = new SelectList(db.Client, "Num_clt", "Num_clt", reservation.Num_clt);
            ViewBag.Num_empl = new SelectList(db.Employé, "Num_empl", "Nom_empl", reservation.Num_empl);
            return View(reservation);
        }

        // GET: reservation_empl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Num_clt = new SelectList(db.Client, "Num_clt", "Num_clt", reservation.Num_clt);
            ViewBag.Num_empl = new SelectList(db.Employé, "Num_empl", "Num_empl", reservation.Num_empl);
            return View(reservation);
        }

        // POST: reservation_empl/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num_res,Dat_res,Typpe_res,Duré_res,Nb_Adult,Nb_Enfant,Num_clt,Num_empl,Prix_res")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Num_clt = new SelectList(db.Client, "Num_clt", "Num_clt", reservation.Num_clt);
            ViewBag.Num_empl = new SelectList(db.Employé, "Num_empl", "Num_empl", reservation.Num_empl);
            return View(reservation);
        }

        // GET: reservation_empl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: reservation_empl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservation.Find(id);
            db.reservation.Remove(reservation);
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
