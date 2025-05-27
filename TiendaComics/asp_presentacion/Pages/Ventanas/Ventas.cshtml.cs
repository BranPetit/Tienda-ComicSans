using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class VentasModel : PageModel
    {
        private IVentasPresentacion? iPresentacion = null;
        private IClientesPresentacion? iClientesPresentacion = null;
        private IVendedoresPresentacion? iVendedoresPresentacion = null;
        private ISucursalesPresentacion? iSucursalesPresentacion = null;
        private IMetodos_de_PagosPresentacion? iMetodos_de_PagosPresentacion = null;

        public VentasModel(IVentasPresentacion iPresentacion,
            IClientesPresentacion iClientesPresentacion,
            IVendedoresPresentacion? iVendedoresPresentacion,
            ISucursalesPresentacion? iSucursalesPresentacion,
            IMetodos_de_PagosPresentacion? iMetodos_de_PagosPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iClientesPresentacion = iClientesPresentacion;
                this.iVendedoresPresentacion = iVendedoresPresentacion;
                this.iSucursalesPresentacion = iSucursalesPresentacion; 
                this.iMetodos_de_PagosPresentacion = iMetodos_de_PagosPresentacion;

                Filtro = new Ventas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Ventas? Actual { get; set; }
        [BindProperty] public Ventas? Filtro { get; set; }
        [BindProperty] public List<Ventas>? Lista { get; set; }
        [BindProperty] public List<Clientes>? Clientes { get; set; }
        [BindProperty] public List<Vendedores>? Vendedores { get; set; }
        [BindProperty] public List<Sucursales>? Sucursales { get; set; }
        [BindProperty] public List<Metodos_de_Pagos>? Metodos_de_Pagos { get; set; }


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

                Filtro!.Codigo = Filtro!.Codigo ?? "";

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorCodigo(Filtro!);
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
                var task = this.iClientesPresentacion!.Listar();
                task.Wait();
                Clientes = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            try
            {
                var task = this.iVendedoresPresentacion!.Listar();
                task.Wait();
                Vendedores = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            try
            {
                var task = this.iSucursalesPresentacion!.Listar();
                task.Wait();
                Sucursales = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            try
            {
                var task = this.iMetodos_de_PagosPresentacion!.Listar();
                task.Wait();
                Metodos_de_Pagos = task.Result;
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
                Actual = new Ventas();
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

                Task<Ventas>? task = null;
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