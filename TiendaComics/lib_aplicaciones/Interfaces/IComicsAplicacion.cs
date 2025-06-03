using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IComicsAplicacion
    {
        void Configurar(string StringConexion);
        List<Comics> PorNombre(Comics? entidad);
        List<Comics> Listar();
        Comics? Guardar(Comics? entidad);
        Comics? Modificar(Comics? entidad);
        Comics? Borrar(Comics? entidad);
        List<Comics> PorFiltros(Comics? entidad);
    }
}