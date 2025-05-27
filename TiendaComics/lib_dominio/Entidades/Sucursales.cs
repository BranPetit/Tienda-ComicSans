
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Sucursales
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        
    }
}
