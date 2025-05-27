
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Vendedores
    {
        [Key] public int Id { get; set; }
        public string? Carnet { get; set; }
        public string? Nombre { get; set; }
        public int Usuario { get; set; }
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
