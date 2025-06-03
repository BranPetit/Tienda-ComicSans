using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class ComicsAplicacion : IComicsAplicacion
    {
        private IConexion? IConexion = null;
        private IAuditoriasAplicacion? IAuditoriasAplicacion = null;

        public ComicsAplicacion(IConexion iConexion, IAuditoriasAplicacion iAuditoriasAplicacion)
        {
            this.IConexion = iConexion;
            this.IAuditoriasAplicacion = iAuditoriasAplicacion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Comics? Borrar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos
            bool enUso = this.IConexion!.Detalles_Ventas!.Any(c => c.Comic == entidad.Id);
            if (enUso)
                throw new Exception("El comic está siendo referenciado");

            this.IConexion!.Comics!.Remove(entidad);
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "admin",
                Entidad = "Comics",
                Operacion = "Borrar",
                Datos = JsonConversor.ConvertirAString(entidad!),
                Fecha = DateTime.Now
            });
            return entidad;
        }

        public Comics? Guardar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Calculos

            this.IConexion!.Comics!.Add(entidad);
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "admin",
                Entidad = "Comics",
                Operacion = "Guardar",
                Datos = JsonConversor.ConvertirAString(entidad!),
                Fecha = DateTime.Now
            });
            return entidad;
        }

        public List<Comics> Listar()
        {
            return this.IConexion!.Comics!
                .Take(20)
                .Include(x => x._Categoria)
                .Include(x => x._Editorial)
                .ToList();
        }

        public List<Comics> PorNombre(Comics? entidad)
        {
            return this.IConexion!.Comics!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Include(x => x._Categoria)
                .Include(x => x._Editorial)
                .ToList();
        }
        public List<Comics> PorFiltros(Comics? entidad)
        {
            var query = this.IConexion!.Comics!
                .Include(x => x._Categoria)
                .Include(x => x._Editorial)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(entidad?.Nombre))
                query = query.Where(x => x.Nombre!.Contains(entidad.Nombre!));

            if (entidad?.Categoria > 0)
                query = query.Where(x => x.Categoria == entidad.Categoria);

            if (entidad?.Editorial > 0)
                query = query.Where(x => x.Editorial == entidad.Editorial);

            return query.ToList();
        }

        public Comics? Modificar(Comics? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Calculos

            var entry = this.IConexion!.Entry<Comics>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            this.IAuditoriasAplicacion!.Configurar(this.IConexion.StringConexion!);
            this.IAuditoriasAplicacion!.Guardar(new Auditorias
            {
                Usuario = "admin",
                Entidad = "Comics",
                Operacion = "Modificar",
                Datos = JsonConversor.ConvertirAString(entidad!),
                Fecha = DateTime.Now
            });
            return entidad;
        }
    }
}
