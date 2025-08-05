using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Voter>? Voter { get; set; }
        DbSet<Candidate>? Candidate { get; set; }
        DbSet<Vote>? Vote { get; set; }


        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
