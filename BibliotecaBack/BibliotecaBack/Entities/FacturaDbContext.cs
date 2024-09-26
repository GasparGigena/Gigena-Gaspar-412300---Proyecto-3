using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaBack.Entities
{
    public partial class FacturaDbContext : DbContext
    {
        public FacturaDbContext()
        {

        }

        public FacturaDbContext(DbContextOptions<FacturaDbContext> options) 
            : base(options)
        {
        }
        
        

        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

    }
}
