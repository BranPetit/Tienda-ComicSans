using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IVendedoresPresentacion
    {
        Task<List<Vendedores>> Listar();
        Task<List<Vendedores>> PorCarnet(Vendedores? entidad);
        Task<Vendedores?> Guardar(Vendedores? entidad);
        Task<Vendedores?> Modificar(Vendedores? entidad);
        Task<Vendedores?> Borrar(Vendedores? entidad);
    }
}