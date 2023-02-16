using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edelweiss.Controllers
{
    public class UtentiController : Controller
    {
        // GET: Utenti
        public ActionResult Login()
        {
            return View();
        }
    }
}