
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Editoriales
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Distribuidor_Asociado { get; set; }
        
    }
}
