using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolaMundoMVC.Controllers
{
    public class EstadosController : Controller
    {
        // GET: Estados
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}