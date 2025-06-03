using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class Metodos_de_PagosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Metodos_de_Pagos>? lista;
        private Metodos_de_Pagos? entidad;
        public Metodos_de_PagosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.Metodos_de_Pagos!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Metodos_de_Pagos()!;
            this.iConexion!.Metodos_de_Pagos!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Tipo = "En linea";
            var entry = this.iConexion!.Entry<Metodos_de_Pagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Metodos_de_Pagos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}