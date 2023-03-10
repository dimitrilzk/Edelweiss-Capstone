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
    public class OrdiniController : Controller
    {
        private ModelDbContext db = new ModelDbContext();


        // GET: Ordini
        public ActionResult Index()
        {

            var ordini = db.Ordini.Include(o => o.Pacchetti);
            return View(ordini.ToList());
        }

        // GET: Ordini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // GET: Ordini/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            //var idPacchetto = PacchettoAcquistato.ListaPacchetti[0].IdPacchetto;
            //ViewBag.ConfermaOrdine = $"Stai comprando il pacchetto {PacchettoAcquistato.ListaPacchetti[0].Nome}";
            ViewBag.IdPacchetto = new SelectList(db.Pacchetti, "IdPacchetto", "Nome");
            return View();
        }

        // POST: Ordini/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "IdOrdine,Nome,Cognome,Email,Cellulare,NumeroCarta,Scadenza,CodiceCVV,IdPacchetto")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                if(PacchettoAcquistato.ListaPacchetti.Count == 0)
                {
                    ViewBag.errore = "Attenzione, devi prima scegliere il pacchetto che vuoi acquistare";
                    return View();
                }
                else
                {
                    ordini.IdPacchetto = PacchettoAcquistato.ListaPacchetti[0].IdPacchetto;
                    ordini.PrezzoAcquisto = PacchettoAcquistato.ListaPacchetti[0].Prezzo;
                    ordini.NomePacchetto = PacchettoAcquistato.ListaPacchetti[0].Nome;
                    ordini.DataAcquisto = PacchettoAcquistato.ListaPacchetti[0].DataAcquisto;
                    db.Ordini.Add(ordini);
                    db.SaveChanges();
                    PacchettoAcquistato.ListaPacchetti.Clear();
                    TempData["successo"] = "Il tuo acquisto è stato effettuato, riceverai il piano e la ricevuta via Email, a presto e grazie!";
                    return RedirectToAction("Create");
                }
                
            }
            return View();
        }

        // GET: Ordini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPacchetto = new SelectList(db.Pacchetti, "IdPacchetto", "Nome", ordini.IdPacchetto);
            return View(ordini);
        }

        // POST: Ordini/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdine,Nome,Cognome,Email,Cellulare,NumeroCarta,Scadenza,CodiceCVV,IdPacchetto,PrezzoAcquisto,NomePacchetto")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPacchetto = new SelectList(db.Pacchetti, "IdPacchetto", "Nome", ordini.IdPacchetto);
            return View(ordini);
        }

        // GET: Ordini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // POST: Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordini ordini = db.Ordini.Find(id);
            db.Ordini.Remove(ordini);
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
