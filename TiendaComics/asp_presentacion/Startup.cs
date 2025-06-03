using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones
            services.AddScoped<ICategoriasPresentacion, CategoriasPresentacion>();
            services.AddScoped<IEditorialesPresentacion, EditorialesPresentacion>();
            services.AddScoped<IComicsPresentacion, ComicsPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IVendedoresPresentacion, VendedoresPresentacion>();
            services.AddScoped<ISucursalesPresentacion, SucursalesPresentacion>();
            services.AddScoped<IMetodos_de_PagosPresentacion, Metodos_de_PagosPresentacion>();
            services.AddScoped<IVentasPresentacion, VentasPresentacion>();
            services.AddScoped<IDetalles_VentasPresentacion, Detalles_VentasPresentacion>();
            services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
            services.AddScoped<IRolesPresentacion, RolesPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();           
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}