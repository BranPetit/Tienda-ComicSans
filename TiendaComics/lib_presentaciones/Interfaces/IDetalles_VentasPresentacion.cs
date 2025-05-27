using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IDetalles_VentasPresentacion
    {
        Task<List<Detalles_Ventas>> Listar();
        Task<List<Detalles_Ventas>> PorCodigoDetalle(Detalles_Ventas? entidad);
        Task<Detalles_Ventas?> Guardar(Detalles_Ventas? entidad);
        Task<Detalles_Ventas?> Modificar(Detalles_Ventas? entidad);
        Task<Detalles_Ventas?> Borrar(Detalles_Ventas? entidad);
    }
}