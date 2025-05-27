
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Detalles_Ventas
    {
        [Key] public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? CodigoDetalle { get; set; }
        public int Venta { get; set; }
        public int Comic { get; set; }
        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Comic")] public Comics? _Comic { get; set; }

    }
}
