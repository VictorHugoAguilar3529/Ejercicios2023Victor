using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
namespace Presentacion.Controllers
{
    public class EstatusAlumnosController : Controller
    {
        NEstatusAlumnos _nEstatusAlumnos = new NEstatusAlumnos();

        // GET: EstatusAlumnos
        public ActionResult Index()
        {
            List<EstatusAlumnos> listEstatus = new List<EstatusAlumnos>();
            listEstatus = _nEstatusAlumnos.Consultar();
            return View(listEstatus);
        }

        // GET: EstatusAlumnos/Details/5
        public ActionResult Details(int id)
        {
            EstatusAlumnos estatusAlumnos = new EstatusAlumnos();
            estatusAlumnos = _nEstatusAlumnos.Consultar(id);
            return View(estatusAlumnos);
        }

        // GET: EstatusAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstatusAlumnos/Create
        [HttpPost]
        public ActionResult Create(EstatusAlumnos estatusAlumnos)
        {
            try
            {
                // TODO: Add insert logic here
                _nEstatusAlumnos.Agregar(estatusAlumnos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Edit/5
        public ActionResult Edit(int id)
        {
            EstatusAlumnos estatusAlumnos = new EstatusAlumnos();
            estatusAlumnos = _nEstatusAlumnos.Consultar(id);
            return View(estatusAlumnos);
        }

        // POST: EstatusAlumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstatusAlumnos estatusAlumnos)
        {
            try
            {
                // TODO: Add update logic here
                _nEstatusAlumnos.Actualizar(estatusAlumnos,id );
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Delete/5
        public ActionResult Delete(int id)
        {
            EstatusAlumnos estatusAlumnos = new EstatusAlumnos();
            estatusAlumnos = _nEstatusAlumnos.Consultar(id);
            return View(estatusAlumnos);
        }

        // POST: EstatusAlumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _nEstatusAlumnos.ELiminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
