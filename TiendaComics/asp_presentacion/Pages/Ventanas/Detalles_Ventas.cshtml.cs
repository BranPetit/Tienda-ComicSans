using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class Detalles_VentasModel : PageModel
    {
        private IDetalles_VentasPresentacion? iPresentacion = null;
        private IComicsPresentacion? iComicsPresentacion = null;
        private IVentasPresentacion? iVentasPresentacion = null;

        public Detalles_VentasModel(IDetalles_VentasPresentacion iPresentacion,
            IComicsPresentacion iComicsPresentacion,
            IVentasPresentacion? iVentasPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iComicsPresentacion = iComicsPresentacion;
                this.iVentasPresentacion = iVentasPresentacion;
                Filtro = new Detalles_Ventas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Detalles_Ventas? Actual { get; set; }
        [BindProperty] public Detalles_Ventas? Filtro { get; set; }
        [BindProperty] public List<Detalles_Ventas>? Lista { get; set; }
        [BindProperty] public List<Comics>? Comics { get; set; }
        [BindProperty] public List<Ventas>? Ventas { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.CodigoDetalle = Filtro!.CodigoDetalle ?? "";

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorCodigoDetalle(Filtro!);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        private void CargarCombox()
        {
            try
            {
                var task = this.iComicsPresentacion!.Listar();
                task.Wait();
                Comics = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            try
            {
                var task = this.iVentasPresentacion!.Listar();
                task.Wait();
                Ventas = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Detalles_Ventas();
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                CargarCombox();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<Detalles_Ventas>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}