using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using Datos;
using Entidades;
using Negocio;


namespace MVC_Razor_ADO.Controllers
{
    public class AlumnosController : Controller
    {
        NAlumno nAlumno = new NAlumno();
        NEstado NEstado = new NEstado();
        NEstatusAlumno nEstatus = new NEstatusAlumno();
        Alumno alumno = new Alumno();

        // GET: Alumnos
        public ActionResult Index()
        {
            List<Alumno> alumnos = new List<Alumno>();
            alumnos = nAlumno.ConsultarTodos();
            return View(alumnos);
        }

        public ActionResult Details(int id)
        {
            alumno = nAlumno.Consultar(id);
            List<Estado> lstEstados = NEstado.ConsultarTodos();
            ViewBag.estados = lstEstados;
            List<EstatusAlumno> ltsestatusAlumnos = nEstatus.ConsultarTodos();
            ViewBag.estatus = ltsestatusAlumnos;
            return View(alumno);
        }
        
        public ActionResult Edit(int id)
        {
            List<Estado> lstEstados = NEstado.ConsultarTodos();
            ViewBag.estados = lstEstados;
            List<EstatusAlumno> ltsestatusAlumnos = nEstatus.ConsultarTodos();
            ViewBag.estatus = ltsestatusAlumnos;
            alumno = nAlumno.Consultar(id);

            return View(alumno);
        }
        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            nAlumno.Actualizar(alumno);

            return View(alumno);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            nAlumno.Eliminar(id);
            return View(alumno);
        }

        public ActionResult Create()
        {
            List<Estado> lstEstados = NEstado.ConsultarTodos();
            ViewBag.estados = lstEstados;
            List<EstatusAlumno> ltsestatusAlumnos = nEstatus.ConsultarTodos();
            ViewBag.estatus = ltsestatusAlumnos;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            nAlumno.Agregar(alumno);
            return View();
        }
    }
}