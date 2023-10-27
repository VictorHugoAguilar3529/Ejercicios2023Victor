using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using Negocio.ServiceReference1;

namespace Negocio
{
    public class NAlumno
    {
        InstitutoTich3Entities _DBContext = new InstitutoTich3Entities();
        List<Alumnos> _ListAlumnos = new List<Alumnos>();
        List<Estados> _ListEstados;
        List<EstatusAlumnos> _estatusAlumnos;
        Alumnos _Alumnos = new Alumnos();

        public List<Alumnos> Consultar()
        {

            _DBContext.Configuration.LazyLoadingEnabled = false;
            _ListAlumnos = _DBContext.Alumnos.ToList();

            return _ListAlumnos;
        }

        public Alumnos Consultar(int id)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            _Alumnos = _DBContext.Alumnos.Find(id);

            return _Alumnos;
        }
        public void Agregar(Alumnos alumnos)
        {
            _DBContext.Configuration.LazyLoadingEnabled = false;
            _DBContext.Alumnos.Add(alumnos);
            _DBContext.SaveChanges();

        }
        public void Actualizar(Alumnos alumnos)
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
                curp = alumnos.curp,
                sueldo = alumnos.sueldo,
                idEstadoOrigen = alumnos.idEstadoOrigen,
                idEstatus = alumnos.idEstatus


            };
            //var entrada = _DBContext.Entry(oCurso);
            //entrada.State = EntityState.Modified;
            _DBContext.Entry(oAlumnos).State = EntityState.Modified;
            _DBContext.SaveChanges();

            _Alumnos = _DBContext.Alumnos.Find(alumnos.id);

        }
        public void Eliminar(int id)
        {
            _Alumnos = _DBContext.Alumnos.Find(id);
            //_DBContext.Entry(_oCurso).State = EntityState.Deleted;
            _DBContext.Alumnos.Remove(_Alumnos);
            _DBContext.SaveChanges();
        }

        public AportacionesIMSS CalcularIMSS(int id)
        {
            Negocio.ServiceReference1.WCFAlumnosClient oWSASoup = new Negocio.ServiceReference1.WCFAlumnosClient();
            ServiceReference1.AportacionesIMSS aportacionesIMSS = oWSASoup.CalcularIMSS(id);

            return aportacionesIMSS;
        }
        public ItemTablaISR CalcularISR(int id)
        {
            
            Negocio.ServiceReference1.WCFAlumnosClient oWSASoup = new Negocio.ServiceReference1.WCFAlumnosClient();
            ServiceReference1.ItemTablaISR tablaISR = oWSASoup.CalcularISR(id);


            return tablaISR;
        }



    }
}
