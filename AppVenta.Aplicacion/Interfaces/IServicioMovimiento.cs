using AppVenta.dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Aplicacion.Interfaces
{
    public interface IServicioMovimiento <TEntidad,TEntidadId> : IAgregar<TEntidad>, IListar<TEntidad,TEntidadId>
    {
        public void Anular(TEntidadId id);
    }
}
