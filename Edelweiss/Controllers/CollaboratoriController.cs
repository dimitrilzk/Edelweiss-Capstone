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
    public class CollaboratoriController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Collaboratori
        public ActionResult Index()
        {
            return View(db.Collaboratori.ToList());
        }

        // GET: Collaboratori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaboratori collaboratori = db.Collaboratori.Find(id);
            if (collaboratori == null)
            {
                return HttpNotFound();
            }
            return View(collaboratori);
        }

        // GET: Collaboratori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collaboratori/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Collaboratori collaboratori)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Assets/Img/" + collaboratori.FileFoto.FileName);
                collaboratori.FileFoto.SaveAs(path);
                collaboratori.Foto = collaboratori.FileFoto.FileName;
                db.Collaboratori.Add(collaboratori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collaboratori);
        }

        // GET: Collaboratori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaboratori collaboratori = db.Collaboratori.Find(id);
            if (collaboratori == null)
            {
                return HttpNotFound();
            }
            return View(collaboratori);
        }

        // POST: Collaboratori/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "IdCollaboratore,Nome,Cognome,Mansione,Cellulare,Email,Foto")]
        public ActionResult Edit(Collaboratori collaboratori)
        {
            if (ModelState.IsValid == true && collaboratori.FileFoto != null)
            {
                string path = Server.MapPath("~/Content/Assets/Img/" + collaboratori.FileFoto.FileName);
                collaboratori.FileFoto.SaveAs(path);
                collaboratori.Foto = collaboratori.FileFoto.FileName;
                db.Entry(collaboratori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }else if(ModelState.IsValid)
            {
                Collaboratori collaboratoreDB = db.Collaboratori.Find(collaboratori.IdCollaboratore);
                collaboratoreDB.Nome = collaboratori.Nome;
                collaboratoreDB.Cognome = collaboratori.Cognome;
                collaboratoreDB.Mansione = collaboratori.Mansione;
                collaboratoreDB.Cellulare = collaboratori.Cellulare;
                collaboratoreDB.Email = collaboratori.Email;
                collaboratoreDB.Foto = db.Collaboratori.Find(collaboratori.IdCollaboratore).Foto;
                db.Entry(collaboratoreDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collaboratori);
        }

        // GET: Collaboratori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaboratori collaboratori = db.Collaboratori.Find(id);
            if (collaboratori == null)
            {
                return HttpNotFound();
            }
            return View(collaboratori);
        }

        // POST: Collaboratori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collaboratori collaboratori = db.Collaboratori.Find(id);
            db.Collaboratori.Remove(collaboratori);
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
