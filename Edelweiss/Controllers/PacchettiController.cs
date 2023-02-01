﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Edelweiss.Models;

namespace Edelweiss.Controllers
{
    public class PacchettiController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        public ActionResult PacchettiPublic()
        {
            return View(db.Pacchetti.ToList());
        }

        // GET: Pacchetti
        public ActionResult Index()
        {
            return View(db.Pacchetti.ToList());
        }

        // GET: Pacchetti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacchetti pacchetti = db.Pacchetti.Find(id);
            if (pacchetti == null)
            {
                return HttpNotFound();
            }
            return View(pacchetti);
        }

        // GET: Pacchetti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacchetti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPacchetto,PrezzoScontato,PrezzoEffettivo,Descrizione,Nome")] Pacchetti pacchetti)
        {
            if (ModelState.IsValid)
            {
                db.Pacchetti.Add(pacchetti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pacchetti);
        }

        // GET: Pacchetti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacchetti pacchetti = db.Pacchetti.Find(id);
            if (pacchetti == null)
            {
                return HttpNotFound();
            }
            return View(pacchetti);
        }

        // POST: Pacchetti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPacchetto,PrezzoScontato,PrezzoEffettivo,Descrizione,Nome")] Pacchetti pacchetti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacchetti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacchetti);
        }

        // GET: Pacchetti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacchetti pacchetti = db.Pacchetti.Find(id);
            if (pacchetti == null)
            {
                return HttpNotFound();
            }
            return View(pacchetti);
        }

        // POST: Pacchetti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacchetti pacchetti = db.Pacchetti.Find(id);
            db.Pacchetti.Remove(pacchetti);
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