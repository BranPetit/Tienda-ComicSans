using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ISucursalesAplicacion
    {
        void Configurar(string StringConexion);
        List<Sucursales> PorNombre(Sucursales? entidad);
        List<Sucursales> Listar();
        Sucursales? Guardar(Sucursales? entidad);
        Sucursales? Modificar(Sucursales? entidad);
        Sucursales? Borrar(Sucursales? entidad);
    }
}