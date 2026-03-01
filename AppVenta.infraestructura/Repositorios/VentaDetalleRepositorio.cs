using AppVenta.dominio;
using AppVenta.dominio.Interfaces.Repositorios;
using AppVenta.infraestructura.datos.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.infraestructura.datos.Repositorios
{
    public class VentaDetalleRepositorio: IRepositorioDetalle<VentaDetalle,Guid>
    {
        private VentaContexto _db;
        public VentaDetalleRepositorio(VentaContexto db)
        {
            _db = db;
        }

        public VentaDetalle Agregar(VentaDetalle tentidad)
        {
            _db.Add(tentidad);
            return tentidad;
        }

        public void GuardarCambios()
        {
            _db.SaveChanges();
        }
    }
}
