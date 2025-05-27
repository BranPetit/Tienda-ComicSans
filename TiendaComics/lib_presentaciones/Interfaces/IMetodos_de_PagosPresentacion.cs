using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMetodos_de_PagosPresentacion
    {
        Task<List<Metodos_de_Pagos>> Listar();
        Task<List<Metodos_de_Pagos>> PorNombre(Metodos_de_Pagos? entidad);
        Task<Metodos_de_Pagos?> Guardar(Metodos_de_Pagos? entidad);
        Task<Metodos_de_Pagos?> Modificar(Metodos_de_Pagos? entidad);
        Task<Metodos_de_Pagos?> Borrar(Metodos_de_Pagos? entidad);
    }
}