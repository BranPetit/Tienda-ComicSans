using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Editoriales>? Editoriales { get; set; }
        DbSet<Comics>? Comics { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Vendedores>? Vendedores { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
        DbSet<Detalles_Ventas>? Detalles_Ventas { get; set; }
        DbSet<Metodos_de_Pagos>? Metodos_de_Pagos { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Auditorias> Auditorias { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}