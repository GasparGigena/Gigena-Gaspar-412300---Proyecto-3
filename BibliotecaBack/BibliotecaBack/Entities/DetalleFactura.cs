using proyecto_Practica02_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBack.Entities
{
    public class DetalleFactura
    {
        public int IdDetalle {  get; set; }
        public int CodFactura { get; set; }
        public Articulo articulo { get; set; }
        public int Cantidad { get; set; }
        public Factura factura { get; set; }


    }
}
