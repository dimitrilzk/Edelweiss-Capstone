using System;
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
    public class ContattiController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Contatti
        public ActionResult Index()
        {
            return View(db.Contatti.ToList());
        }

        // GET: Contatti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatti contatti = db.Contatti.Find(id);
            if (contatti == null)
            {
                return HttpNotFound();
            }
            return View(contatti);
        }

        // GET: Contatti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contatti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContatto,Nome,Cognome,Email,Cellulare,Messaggio")] Contatti contatti)
        {
            if (ModelState.IsValid)
            {
                db.Contatti.Add(contatti);
                db.SaveChanges();
                TempData["MessaggioInviato"] = "Il tuo messaggio è stato inviato con successo, riceverai una risposta via Email al più presto, Grazie!";
                return RedirectToAction("Create");
            }

            return View(contatti);
        }

        // GET: Contatti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatti contatti = db.Contatti.Find(id);
            if (contatti == null)
            {
                return HttpNotFound();
            }
            return View(contatti);
        }

        // POST: Contatti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContatto,Nome,Cognome,Email,Cellulare,Messaggio")] Contatti contatti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contatti);
        }

        // GET: Contatti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatti contatti = db.Contatti.Find(id);
            if (contatti == null)
            {
                return HttpNotFound();
            }
            return View(contatti);
        }

        // POST: Contatti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contatti contatti = db.Contatti.Find(id);
            db.Contatti.Remove(contatti);
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
