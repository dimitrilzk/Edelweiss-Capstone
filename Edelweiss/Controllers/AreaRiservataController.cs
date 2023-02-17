using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edelweiss.Controllers
{
    public class AreaRiservataController : Controller
    {
        [Authorize]
        // GET: AreaRiservata
        public ActionResult Index()
        {
            return View();
        }
    }
}