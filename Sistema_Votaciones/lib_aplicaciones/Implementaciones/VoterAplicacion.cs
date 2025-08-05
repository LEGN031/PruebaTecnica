using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_aplicaciones.Interfaces;
using System.Diagnostics.Metrics;

namespace lib_aplicaciones.Implementaciones
{
    public class VoterAplicacion : IVoterAplicacion
    {
        private IConexion? IConexion = null;

        public VoterAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public Voter? Borrar(Voter? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var existente = this.IConexion!.Voter!.FirstOrDefault(x => x.Id == entidad.Id);
            if (existente == null)
                throw new Exception("lbNoExiste");

            if (existente.HasVoted)
                throw new Exception("lbVotoRegistradoNoBorrar");

            this.IConexion!.Voter!.Remove(existente);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public Voter? Guardar(Voter? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id != 0)
                throw new Exception("lbYaSeGuardo");

            VerificarQueNoEsCandidato(entidad);
            

            this.IConexion!.Voter!.Add(entidad);

            //VerificarVoto(entidad);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public List<Voter> Listar()
        {
            
            this.IConexion!.SaveChanges();

            return this.IConexion!.Voter!.Take(20).ToList();
        }

        public List<Voter> PorId(Voter? entidad)
        {

            if (entidad == null || entidad.Id<=0)
                throw new Exception("lbFaltaInformacion");

            
            this.IConexion!.SaveChanges();

            return this.IConexion!.Voter!.Where(x => x.Id == entidad.Id).ToList();
        }

        public Voter? Modificar(Voter? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
           

            var entry = this.IConexion!.Entry<Voter>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        private void VerificarQueNoEsCandidato(Voter? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            
            if (string.IsNullOrWhiteSpace(entidad.Cedula))
                throw new Exception("lbCedulaInvalida");

            var existe = IConexion!.Candidate!
                .Any(c => c.Cedula == entidad.Cedula);

            if (existe)
                throw new Exception("lbEsCandidato"); 
        }
/*
        private void VerificarVoto(Voter? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            var existente = this.IConexion!.Voter!.FirstOrDefault(x => x.Id == entidad.Id);
            if (existente == null)
                throw new Exception("lbNoExiste");

            if (existente.HasVoted)
                throw new Exception("lbYaVoto");
        }

        */
    }
}
