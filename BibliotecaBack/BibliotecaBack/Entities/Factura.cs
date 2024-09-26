using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBack.Entities
{
    public class Factura
    {
        public int Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public int FormaPago { get; set; }
        public string Cliente { get; set; }
        public DetalleFactura Detalle { get; set; }
    }
}
