using Edelweiss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Edelweiss.Controllers
{
    public class UtentiController : Controller
    {
        ModelDbContext db = new ModelDbContext();
        // GET: Utenti
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utenti u)
        {
            string username = u.Username;
            string password = u.PasswordUtente;
            var user = db.Utenti.Where(x => x.Username == username && x.PasswordUtente == password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ViewBag.Errore = "Username e/o Password errati";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}