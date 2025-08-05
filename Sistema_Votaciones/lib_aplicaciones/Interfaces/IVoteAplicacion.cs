using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IVoteAplicacion
    {
        void Configurar(string StringConexion);
        List<Vote> PorCode(Vote? entidad);
        List<Vote> Listar();
        Vote? Guardar(Vote? entidad);
        Vote? Modificar(Vote? entidad);
        Vote? Borrar(Vote? entidad);
        object? Statistics(Vote? entidad);
    }
}