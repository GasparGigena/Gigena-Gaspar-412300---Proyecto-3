using proyecto_Practica02_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBack.Repositories
{
    public interface IArticuloRepositorio
    {
        List<Articulo> GetArticulos();
        bool Save(Articulo articulo);
        bool Update(Articulo articulo);
        bool Delete(int id);
    }
}
