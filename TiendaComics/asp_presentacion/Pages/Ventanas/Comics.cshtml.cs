using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class ComicsModel : PageModel
    {
        private IComicsPresentacion? iPresentacion = null;
        private ICategoriasPresentacion? iCategoriasPresentacion = null;
        private IEditorialesPresentacion? iEditorialesPresentacion = null;

        public ComicsModel(IComicsPresentacion iPresentacion,
            ICategoriasPresentacion iCategoriasPresentacion,
            IEditorialesPresentacion iEditorialesPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iCategoriasPresentacion = iCategoriasPresentacion;
                this.iEditorialesPresentacion = iEditorialesPresentacion;
                Filtro = new Comics();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Comics? Actual { get; set; }
        [BindProperty] public Comics? Filtro { get; set; }
        [BindProperty] public List<Comics>? Lista { get; set; }
        [BindProperty] public List<Categorias>? Categorias { get; set; }
        [BindProperty] public List<Editoriales>? Editoriales { get; set; }
        [BindProperty] public List<Comics>? Carrito { get; set; }

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

                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Filtro!.Categoria = Filtro!.Categoria;
                Filtro!.Editorial = Filtro!.Editorial;

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorFiltros(Filtro!);
                task.Wait();
                Lista = task.Result;
                Actual = null;

                CargarCombox();
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
                var task = this.iCategoriasPresentacion!.Listar();
                task.Wait();
                Categorias = task.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            try
            {
                var task = this.iEditorialesPresentacion!.Listar();
                task.Wait();
                Editoriales = task.Result;
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
                Actual = new Comics();
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

                Task<Comics>? task = null;
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
        public IActionResult OnPostAgregarAlCarrito(int id)
        {
            try
            {
                
                var task = this.iPresentacion!.PorFiltros(new Comics()); 
                task.Wait();
                Lista = task.Result;

                var comic = Lista?.FirstOrDefault(c => c.Id == id);
                if (comic != null)
                {
                    var carritoStr = HttpContext.Session.GetString("Carrito");
                    var carrito = string.IsNullOrEmpty(carritoStr)
                        ? new List<Comics>()
                        : JsonConversor.ConvertirAObjeto<List<Comics>>(carritoStr);

                    carrito.Add(comic);
                    HttpContext.Session.SetString("Carrito", JsonConversor.ConvertirAString(carrito));
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            return RedirectToPage();
        }
    }
}