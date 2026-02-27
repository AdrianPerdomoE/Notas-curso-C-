using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }

        public int cantidadEnStock { get; set; }
        public List<VentaDetalle> ventaDetalles { get; set; }
    }
}
