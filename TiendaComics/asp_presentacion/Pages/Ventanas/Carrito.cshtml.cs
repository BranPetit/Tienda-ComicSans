using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class CarritoModel : PageModel
    {
        public List<Comics> Items { get; set; } = new();
        public decimal Total { get; set; }

        public void OnGet()
        {
            var carritoStr = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(carritoStr))
            {
                Items = JsonConversor.ConvertirAObjeto<List<Comics>>(carritoStr);
                Total = Items.Sum(i => i.Precio);
            }
        }
        public IActionResult OnPostQuitarDelCarrito(int id)
        {
            var carritoStr = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(carritoStr))
            {
                var carrito = JsonConversor.ConvertirAObjeto<List<Comics>>(carritoStr);
                var itemAEliminar = carrito.FirstOrDefault(c => c.Id == id);
                if (itemAEliminar != null)
                {
                    carrito.Remove(itemAEliminar);
                    HttpContext.Session.SetString("Carrito", JsonConversor.ConvertirAString(carrito));
                }
            }

            return RedirectToPage();
        }
    }
}