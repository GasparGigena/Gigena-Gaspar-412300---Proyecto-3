using Biblioteca.Data;
using BibliotecaBack.Repositories;
using proyecto_Practica02_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Services;

public class ArticuloManager : IArticuloManager
{
    private IArticuloRepositorio _repositorio;
    public ArticuloManager()
    {
        _repositorio = new ArticuloRepository();
    }

    public List<Articulo> GetArticulos()
    {
        return _repositorio.GetArticulos();
    }

    public bool AgregarArticulo(Articulo articulo)
    {
        return _repositorio.Save(articulo);
    }

    public bool BorrarArticulo(int id)
    {
        return _repositorio.Delete(id);
    }

    public bool EditarArticulo(Articulo articulo)
    {
        return _repositorio.Update(articulo);
    }
}
