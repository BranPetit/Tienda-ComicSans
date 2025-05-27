

using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Metodos_de_Pagos
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        
    }
}
