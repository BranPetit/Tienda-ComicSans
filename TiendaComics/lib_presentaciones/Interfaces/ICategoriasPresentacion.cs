﻿using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICategoriasPresentacion
    {
        Task<List<Categorias>> Listar();
        Task<List<Categorias>> PorNombre(Categorias? entidad);
        Task<Categorias?> Guardar(Categorias? entidad);
        Task<Categorias?> Modificar(Categorias? entidad);
        Task<Categorias?> Borrar(Categorias? entidad);
    }
}