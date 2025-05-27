using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Detalles_VentasAplicacion : IDetalles_VentasAplicacion
    {
        private IConexion? IConexion = null;
        private IAuditoriasAplicacion? IAuditoriasAplicacion = null;

        public Detalles_VentasAplicacion(IConexion iConexion, IAuditoriasAplicacion iAuditoriasAplicacion)
        {
            this.IConexion = iConexion;
            this.IAuditoriasAplicacion = iAuditoriasAplicacion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Detalles_Ventas? Borrar(Detalles_Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            this.IConexion!.Detalles_Ventas!.Remove(entidad);
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "Admin",
                Entidad = "Detalles Ventas",
                Operacion = "Borrar",
                Datos = JsonConversor.ConvertirAString(entidad!),
                Fecha = DateTime.Now
            });
            return entidad;
        }

        public Detalles_Ventas? Guardar(Detalles_Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Detalles_Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "Admin",
                Entidad = "Detalles Ventas",
                Operacion = "Guardar",
                Datos = JsonConversor.ConvertirAString(entidad!),
                Fecha = DateTime.Now
            });
            return entidad;
        }

        public List<Detalles_Ventas> Listar()
        {
            return this.IConexion!.Detalles_Ventas!
                .Take(20)
                .Include(x => x._Comic)
                    .ThenInclude(c => c!._Editorial)
                 .Include(x => x._Comic)
                    .ThenInclude(c => c!._Categoria)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Cliente)
                        .ThenInclude(w => w!._Usuario)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Vendedor)
                        .ThenInclude(w => w!._Usuario)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Sucursal)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Metodo_de_Pago)
                .ToList();
        }

        public List<Detalles_Ventas> PorCodigoDetalle(Detalles_Ventas? entidad)
        {
            return this.IConexion!.Detalles_Ventas!
                .Where(x => x.CodigoDetalle!.Contains(entidad!.CodigoDetalle!))
                .Include(x => x._Comic)
                    .ThenInclude(c => c!._Editorial)
                 .Include(x => x._Comic)
                    .ThenInclude(c => c!._Categoria)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Cliente)
                        .ThenInclude(w => w!._Usuario)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Vendedor)
                        .ThenInclude(w => w!._Usuario)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Sucursal)
                .Include(x => x._Venta)
                    .ThenInclude(v => v!._Metodo_de_Pago)
                .ToList();
        }

        public Detalles_Ventas? Modificar(Detalles_Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Calculos

            var entry = this.IConexion!.Entry<Detalles_Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "Admin",
                Entidad = "Detalles Ventas",
                Operacion = "Modificar",
                Datos = JsonConversor.ConvertirAString(entidad!),
                Fecha = DateTime.Now
            });
            return entidad;
        }
    }
}
