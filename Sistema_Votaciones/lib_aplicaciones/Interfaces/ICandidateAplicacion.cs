using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ICandidateAplicacion
    {
        void Configurar(string StringConexion);
        List<Candidate> PorId(Candidate? entidad);
        List<Candidate> Listar();
        Candidate? Guardar(Candidate? entidad);
        Candidate? Modificar(Candidate? entidad);
        Candidate? Borrar(Candidate? entidad);
    }
}