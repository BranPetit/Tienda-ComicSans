using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IEditorialesAplicacion
    {
        void Configurar(string StringConexion);
        List<Editoriales> PorNombre(Editoriales? entidad);
        List<Editoriales> Listar();
        Editoriales? Guardar(Editoriales? entidad);
        Editoriales? Modificar(Editoriales? entidad);
        Editoriales? Borrar(Editoriales? entidad);
    }
}