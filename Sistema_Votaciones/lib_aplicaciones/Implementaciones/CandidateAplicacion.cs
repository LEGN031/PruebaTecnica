using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_aplicaciones.Interfaces;
using System.Diagnostics.Metrics;

namespace lib_aplicaciones.Implementaciones
{
    public class CandidateAplicacion : ICandidateAplicacion
    {
        private IConexion? IConexion = null;

        public CandidateAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public Candidate? Borrar(Candidate? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");



            this.IConexion!.Candidate!.Remove(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public Candidate? Guardar(Candidate? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id != 0)
                throw new Exception("lbYaSeGuardo");

            

            this.IConexion!.Candidate!.Add(entidad);

            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<Candidate> Listar()
        {

            this.IConexion!.SaveChanges();

            return this.IConexion!.Candidate!.Take(20).ToList();
        }

        public List<Candidate> PorId(Candidate? entidad)
        {

            if (entidad == null || entidad.Id <= 0)
                throw new Exception("lbFaltaInformacion");


            this.IConexion!.SaveChanges();

            return this.IConexion!.Candidate!.Where(x => x.Id == entidad.Id).ToList();
        }

        public Candidate? Modificar(Candidate? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");


            var entry = this.IConexion!.Entry<Candidate>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }



    }
}
