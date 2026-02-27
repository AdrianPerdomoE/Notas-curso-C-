using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio
{
    public class Venta
    {
        public Guid Id { get; set; }
        public DateTime fecha { get; set; }
        public long numeroVento { get; set; }
        public string concepto { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
        public decimal impuesto { get; set; }
        public List<VentaDetalle> ventaDetalles { get; set; }
    }
}
