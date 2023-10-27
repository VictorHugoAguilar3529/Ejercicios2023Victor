using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;
using Entidades;
using Negocio;
using Negocio.ServiceReference1;

namespace Presentacion.Controllers
{
    public class AlumnosController : Controller
    {
        InstitutoTich3Entities _DBContext = new InstitutoTich3Entities();
        NAlumno _nAlumno = new NAlumno();
        NEstado _nEstado = new Negocio.NEstado();
        NEstatus _NEstatus = new NEstatus();
        List<Alumnos> _LtsAlumno;
        List<Estados> _LtsEstados;
        List<EstatusAlumnos> _EstatusAlumno;
        Alumnos _Alumnos = new Alumnos();
        // GET: Alumnos
        public ActionResult Index()
        {
            _LtsAlumno = _nAlumno.Consultar();
            return View(_LtsAlumno);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            _Alumnos = _nAlumno.Consultar(id);
            return View(_Alumnos);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            _LtsEstados = _DBContext.Estados.ToList();
            _EstatusAlumno = _DBContext.EstatusAlumnos.ToList();
            ViewBag.estados = _LtsEstados;
            ViewBag.estatus = _EstatusAlumno;
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    _nAlumno.Agregar(alumnos);

                   
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            _LtsEstados = _DBContext.Estados.ToList();
            _EstatusAlumno = _DBContext.EstatusAlumnos.ToList();
            ViewBag.estados = _LtsEstados;
            ViewBag.estatus = _EstatusAlumno;
            _Alumnos = _nAlumno.Consultar(id);
            return View(_Alumnos);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumnos alumnos)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    _nAlumno.Actualizar(alumnos);
                  
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            _Alumnos = _nAlumno.Consultar(id);
            return View(_Alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _nAlumno.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult _AportacionesIMSS(int id)
        {
            NAlumno nAlumno = new NAlumno();
            AportacionesIMSS iMSS = new AportacionesIMSS();
            iMSS = nAlumno.CalcularIMSS(id);
            return PartialView(iMSS);
        }

        public ActionResult _TablaISR(int id)
        {
            NAlumno nAlumno = new NAlumno();
            ItemTablaISR itemTablaISR = new ItemTablaISR();
            itemTablaISR = nAlumno.CalcularISR(id);
            return PartialView(itemTablaISR);
        }

    }
}
