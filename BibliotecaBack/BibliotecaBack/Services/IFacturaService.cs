using BibliotecaBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBack.Services
{
    public interface IFacturaService
    {
        List<Factura> GetAll();
        bool Save(Factura factura);
        bool Delete(int id);
        bool Update(Factura factura, int id);
    }
}
