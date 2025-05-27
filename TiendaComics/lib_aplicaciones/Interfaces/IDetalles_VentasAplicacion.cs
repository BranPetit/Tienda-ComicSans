using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IDetalles_VentasAplicacion
    {
        void Configurar(string StringConexion);
        List<Detalles_Ventas> PorCodigoDetalle(Detalles_Ventas? entidad);
        List<Detalles_Ventas> Listar();
        Detalles_Ventas? Guardar(Detalles_Ventas? entidad);
        Detalles_Ventas? Modificar(Detalles_Ventas? entidad);
        Detalles_Ventas? Borrar(Detalles_Ventas? entidad);
    }
}