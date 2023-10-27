using MVC_Razor_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace MVC_Razor_EF.Controllers
{
    public class AlumnoController : Controller
    {
        InstitutoTich3Entities1 _DBContext = new InstitutoTich3Entities1();
        List<Alumnos> listAlumnos;
        List<Estados> listEstados;
        List<EstatusAlumnos> lisEstatus;
        
        EstatusAlumnos EstatusAlumnos;
        Alumnos _Alumnos;
        // GET: Alumno
        public ActionResult Index()
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            listAlumnos = _DBContext.Alumnos.ToList();
            return View(listAlumnos);
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            listEstados = _DBContext.Estados.ToList();
            lisEstatus = _DBContext.EstatusAlumnos.ToList();
            ViewBag.estados = listEstados;
            ViewBag.estatus = lisEstatus;
            _Alumnos = _DBContext.Alumnos.Find(id);
            return View(_Alumnos);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            listEstados = _DBContext.Estados.ToList();
            lisEstatus = _DBContext.EstatusAlumnos.ToList();
            ViewBag.estados = listEstados;
            ViewBag.estatus = lisEstatus;
            return View();
        }

        // POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumnos)
        {
            try
            {
                _DBContext.Alumnos.Add(alumnos);
                _DBContext.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            listEstados = _DBContext.Estados.ToList();
            lisEstatus = _DBContext.EstatusAlumnos.ToList();
            ViewBag.estados = listEstados;
            ViewBag.estatus = lisEstatus;
            _Alumnos = _DBContext.Alumnos.Find(id);
            return View(_Alumnos);
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumnos alumnos)
        {
            Alumnos oAlumnos = new Alumnos()
            {
                id = (short)(alumnos.id),
                nombre = alumnos.nombre,
                primerApellido = alumnos.primerApellido,
                segundoApellido = alumnos.segundoApellido,
                correo = alumnos.correo,
                telefono = alumnos.telefono,
                fechaNacimiento = alumnos.fechaNacimiento,
                curp =alumnos.curp,
                sueldo =alumnos.sueldo,
                idEstadoOrigen = alumnos.idEstadoOrigen,
                idEstatus = alumnos.idEstatus

                
        };
            //var entrada = _DBContext.Entry(oCurso);
            //entrada.State = EntityState.Modified;
            _DBContext.Entry(oAlumnos).State = EntityState.Modified;
            _DBContext.SaveChanges();

            _Alumnos = _DBContext.Alumnos.Find(alumnos.id);

            return View("Index");
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            listEstados = _DBContext.Estados.ToList();
            lisEstatus = _DBContext.EstatusAlumnos.ToList();
            ViewBag.estados = listEstados;
            ViewBag.estatus = lisEstatus;
            _Alumnos = _DBContext.Alumnos.Find(id);
            return View(_Alumnos);
        }

        // POST: Alumno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _Alumnos = _DBContext.Alumnos.Find(id);
                //_DBContext.Entry(_oCurso).State = EntityState.Deleted;
                _DBContext.Alumnos.Remove(_Alumnos);
                _DBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
