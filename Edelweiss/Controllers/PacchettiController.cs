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
    [Authorize]
    public class PacchettiController : Controller
    {
        private ModelDbContext db = new ModelDbContext();
        [AllowAnonymous]
        public ActionResult DetailsForPubblic(int? id)
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
        [AllowAnonymous]
        public ActionResult AggiungiCarrello(int id)
        {
            PacchettoAcquistato.ListaPacchetti.Clear();
            PacchettoAcquistato p1 = new PacchettoAcquistato();
            p1.IdPacchetto = id;
            p1.Nome = db.Pacchetti.Find(id).Nome;
            p1.Prezzo = db.Pacchetti.Find(id).PrezzoEffettivo;
            p1.DataAcquisto = DateTime.Now;
            p1.Dettaglio1 = db.Pacchetti.Find(id).Dettaglio1;
            p1.Dettaglio2 = db.Pacchetti.Find(id).Dettaglio2;
            p1.Dettaglio3 = db.Pacchetti.Find(id).Dettaglio3;
            p1.Dettaglio4 = db.Pacchetti.Find(id).Dettaglio4;
            p1.Dettaglio5 = db.Pacchetti.Find(id).Dettaglio5;
            p1.Dettaglio6 = db.Pacchetti.Find(id).Dettaglio6;
            PacchettoAcquistato.ListaPacchetti.Add(p1);
            return RedirectToAction("Create", "Ordini");
        }
        [AllowAnonymous]
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
        public ActionResult Create([Bind(Include = "IdPacchetto,PrezzoScontato,PrezzoEffettivo,Descrizione," +
            "Nome,Dettaglio1,Dettaglio2,Dettaglio3,Dettaglio4,Dettaglio5,Dettaglio6")] Pacchetti pacchetti)
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
        public ActionResult Edit([Bind(Include = "IdPacchetto,PrezzoScontato,PrezzoEffettivo,Descrizione," +
            "Nome,Dettaglio1,Dettaglio2,Dettaglio3,Dettaglio4,Dettaglio5,Dettaglio6")] Pacchetti pacchetti)
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
