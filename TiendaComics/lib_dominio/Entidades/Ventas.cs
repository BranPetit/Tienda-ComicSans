
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Ventas
    {
        [Key] public int Id { get; set; }
        public string? Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cliente { get; set; }
        public int Vendedor { get; set; }
        public int Metodo_de_Pago { get; set; }
        public int Sucursal { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Vendedor")] public Vendedores? _Vendedor { get; set; }
        [ForeignKey("Metodo_de_Pago")] public Metodos_de_Pagos? _Metodo_de_Pago { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }

      
    }
}
