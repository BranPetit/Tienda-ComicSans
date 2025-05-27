using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMetodos_de_PagosAplicacion
    {
        void Configurar(string StringConexion);
        List<Metodos_de_Pagos> PorNombre(Metodos_de_Pagos? entidad);
        List<Metodos_de_Pagos> Listar();
        Metodos_de_Pagos? Guardar(Metodos_de_Pagos? entidad);
        Metodos_de_Pagos? Modificar(Metodos_de_Pagos? entidad);
        Metodos_de_Pagos? Borrar(Metodos_de_Pagos? entidad);
    }
}