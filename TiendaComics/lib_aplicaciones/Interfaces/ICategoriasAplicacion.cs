using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ICategoriasAplicacion
    {
        void Configurar(string StringConexion);
        List<Categorias> PorNombre(Categorias? entidad);
        List<Categorias> Listar();
        Categorias? Guardar(Categorias? entidad);
        Categorias? Modificar(Categorias? entidad);
        Categorias? Borrar(Categorias? entidad);
    }
}