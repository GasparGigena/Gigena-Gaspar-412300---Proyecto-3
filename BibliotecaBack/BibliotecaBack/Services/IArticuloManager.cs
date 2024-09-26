using proyecto_Practica02_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public interface IArticuloManager
    {
        List<Articulo> GetArticulos();
        bool AgregarArticulo(Articulo articulo);
        bool BorrarArticulo(int id);
        bool EditarArticulo(Articulo articulo);
    }
}
