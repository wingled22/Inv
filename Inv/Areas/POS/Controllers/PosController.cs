using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inv.Areas.POS.Controllers
{
    public class PosController : Controller
    {
        // GET: POS/Pos
        public ActionResult Index()
        {
            return View();
        }
    }
}