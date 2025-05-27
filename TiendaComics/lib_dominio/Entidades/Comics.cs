


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Comics
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public Decimal Precio { get; set; }
        public int Editorial { get; set;}
        public int Categoria { get; set;}
        [ForeignKey("Editorial")] public Editoriales? _Editorial { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }

        
    }
}
