using BibliotecaBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBack.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaService _repository;
        public FacturaService(IFacturaService facturaRepository)
        {
            _repository = facturaRepository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Factura> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Save(Factura factura)
        {
            return _repository.Save(factura);
        }

        public bool Update(Factura factura, int id)
        {
            return _repository.Update(factura, id);
        }
    }
}
