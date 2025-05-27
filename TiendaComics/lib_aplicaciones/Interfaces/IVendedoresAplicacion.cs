using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IVendedoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Vendedores> PorCarnet(Vendedores? entidad);
        List<Vendedores> Listar();
        Vendedores? Guardar(Vendedores? entidad);
        Vendedores? Modificar(Vendedores? entidad);
        Vendedores? Borrar(Vendedores? entidad);
    }
}