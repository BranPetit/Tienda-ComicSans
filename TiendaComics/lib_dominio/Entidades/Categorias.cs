
using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Categorias
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Edad_Recomendada { get; set; }
        
    }


}
