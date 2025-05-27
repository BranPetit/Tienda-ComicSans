using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISucursalesPresentacion
    {
        Task<List<Sucursales>> Listar();
        Task<List<Sucursales>> PorNombre(Sucursales? entidad);
        Task<Sucursales?> Guardar(Sucursales? entidad);
        Task<Sucursales?> Modificar(Sucursales? entidad);
        Task<Sucursales?> Borrar(Sucursales? entidad);
    }
}