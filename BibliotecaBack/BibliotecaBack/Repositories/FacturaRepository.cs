using BibliotecaBack.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBack.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FacturaDbContext _context;

        public FacturaRepository(FacturaDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var factura = _context.Facturas.Find(id);
            if (factura != null)
            {
                factura.Fecha = DateTime.Now;
                factura.Codigo = id;
                _context.Facturas.Update(factura);
                return _context.SaveChanges() > 0;
            }
            return false;

        }

        public List<Factura> GetAll()
        {
            return _context.Facturas
                .Where(x => !x.Fecha.HasValue)
                .ToList();
        }

        public bool Save(Factura factura)
        {
            _context.Facturas.Add(factura);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Factura factura, int id)
        {
            DetalleFactura detalle;
            var entity = _context.Facturas.Find(id);
            if (entity == null)
            {
                return false;
            }
            entity.Fecha = factura.Fecha;
            entity.Codigo = factura.Codigo;
            entity.Cliente = factura.Cliente;
            entity.FormaPago = factura.FormaPago;
            entity.Detalle = detalle = factura.Detalle;
            _context.Facturas.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
