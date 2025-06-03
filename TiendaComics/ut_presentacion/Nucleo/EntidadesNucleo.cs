using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Categorias? Categorias()
        {
            var entidad = new Categorias();
            entidad.Nombre = "Manwha";
            entidad.Edad_Recomendada = "15+";
            return entidad;
        }

        public static Editoriales? Editoriales()
        {
            var entidad = new Editoriales();
            entidad.Nombre = "Penguin";
            entidad.Distribuidor_Asociado = "Norma";
            
            return entidad;
        }

        public static Comics? Comics()
        {
            var entidad = new Comics();

            entidad.Nombre = "Superhéroes";
            entidad.Precio = 19900.00m;
            entidad.Editorial = 1;
            entidad.Categoria = 1;
            entidad.Imagen = "test";
            
            return entidad;
        }
        
        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Cedula = "777" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            entidad.Nombre = "Camilo";
            entidad.Usuario = 1;
            
            return entidad;

        }

        public static Vendedores? Vendedores()
        {
            var entidad = new Vendedores();
            entidad.Carnet = "778" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            entidad.Usuario = 1;
            entidad.Nombre = "Julian";
            
            return entidad;
        }

        public static Sucursales? Sucursales()
        {
            var entidad = new Sucursales();
            entidad.Nombre = "LA ESTRELLA";
            entidad.Direccion = "Calle 23A 108-32";
            
            return entidad;
        }

        public static Metodos_de_Pagos? Metodos_de_Pagos()
        {
            var entidad = new Metodos_de_Pagos();
            entidad.Nombre = "Efecty";
            entidad.Tipo = "Presencial";
            
            return entidad;
        }

        public static Ventas? Ventas()
        {
            var entidad = new Ventas();
            entidad.Sucursal = 1;
            entidad.Cliente = 1;
            entidad.Vendedor = 1;
            entidad.Fecha = DateTime.Now;
            entidad.Codigo = "V-20250401-008";
            entidad.Metodo_de_Pago = 1;

            
            return entidad;
        }

        public static Detalles_Ventas? Detalles_Ventas()
        {
            var entidad = new Detalles_Ventas();
            entidad.CodigoDetalle = "1";
            entidad.Comic = 1;
            entidad.Venta = 2;
            entidad.Cantidad = 1;
           
            return entidad;
        }
    }
}
