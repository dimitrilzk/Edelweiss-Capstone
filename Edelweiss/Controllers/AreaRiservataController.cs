using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edelweiss.Controllers
{
    [Authorize]
    public class AreaRiservataController : Controller
    {
        // GET: AreaRiservata
        public ActionResult Index()
        {
            return View();
        }
    }
}