using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IVoterAplicacion
    {
        void Configurar(string StringConexion);
        List<Voter> PorId(Voter? entidad);
        List<Voter> Listar();
        Voter? Guardar(Voter? entidad);
        Voter? Modificar(Voter? entidad);
        Voter? Borrar(Voter? entidad);
    }
}