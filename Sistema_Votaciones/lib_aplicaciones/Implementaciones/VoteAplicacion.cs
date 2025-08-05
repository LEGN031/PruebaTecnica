using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_aplicaciones.Interfaces;
using System.Diagnostics.Metrics;

namespace lib_aplicaciones.Implementaciones
{
    public class VoteAplicacion : IVoteAplicacion
    {
        private IConexion? IConexion = null;

        public VoteAplicacion(IConexion? iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string? stringConexion)
        {
            this.IConexion!.StringConexion = stringConexion;
        }

        public Vote? Borrar(Vote? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var votoDb = this.IConexion!.Vote!.FirstOrDefault(v => v.Id == entidad.Id);
            if (votoDb == null)
                throw new Exception("lbVotoNoExiste");

            var voter = this.IConexion.Voter!.FirstOrDefault(v => v.Id == votoDb.VoterId);
            if (voter == null)
                throw new Exception("lbVotanteNoExiste");

            voter!.HasVoted = false;
            this.IConexion!.Voter!.Update(voter);


            this.IConexion!.Vote!.Remove(votoDb);
            this.IConexion!.SaveChanges();
            return entidad;

        }

        public Vote? Guardar(Vote? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id != 0)
                throw new Exception("lbYaSeGuardo");


            var votante = this.IConexion!.Voter!.FirstOrDefault(v => v.Id == entidad.VoterId);
            if (votante == null)
                throw new Exception("lbVotanteNoExiste");

            if (votante.HasVoted)
                throw new Exception("lbYaVoto");

            var candidato = this.IConexion!.Candidate!.FirstOrDefault(c => c.Id == entidad.CandidateId);
            if (candidato == null)
                throw new Exception("lbCandidatoNoExiste");

            this.IConexion!.Vote!.Add(entidad);

            votante.HasVoted = true;
            this.IConexion!.Voter!.Update(votante);

            candidato.Votes++;
            this.IConexion!.Candidate!.Update(candidato);


            this.IConexion.SaveChanges();
            return entidad;

        }

        public List<Vote> Listar()
        {

            this.IConexion!.SaveChanges();

            return this.IConexion!.Vote!.Take(20).ToList();
        }

        public List<Vote> PorCode(Vote? entidad)
        {

            if (entidad == null || string.IsNullOrWhiteSpace(entidad.Code))
                throw new Exception("lbFaltaInformacion");


            this.IConexion!.SaveChanges();

            return this.IConexion!.Vote!.Where(x => x.Code!.Contains(entidad!.Code!)).ToList();
        }

        public Vote? Modificar(Vote? entidad)
        {

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");


            var entry = this.IConexion!.Entry<Vote>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public object Statistics(Vote? entidad)
        {
            var totalVotos = this.IConexion!.Vote!.Count();

            var votosPorCandidato = this.IConexion.Vote!
            .GroupBy(v => v.CandidateId)
            .Select(g => new
            {
                CandidateId = g.Key,
                NombreCandidato = this.IConexion.Candidate!.FirstOrDefault(c => c.Id == g.Key)!.Name,
                TotalVotos = g.Count(),
                Porcentaje = totalVotos == 0 ? 0 : ((double)g.Count() / totalVotos) * 100
            })
            .ToList();

            var totalVotantesQueVotaron = this.IConexion.Voter!.Count(v => v.HasVoted);

            return new
            {
                TotalVotosEmitidos = totalVotos,
                TotalVotantesQueVotaron = totalVotantesQueVotaron,
                EstadisticasPorCandidato = votosPorCandidato
            };

        }



    }
}
