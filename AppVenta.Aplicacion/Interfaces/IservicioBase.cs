using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.dominio.Interfaces;
namespace AppVenta.Aplicacion.Interfaces
{
    public interface IservicioBase<TEntidad,TEntidadId>: IAgregar<TEntidad>, IEliminar<TEntidadId>, IEditar<TEntidad>, IListar<TEntidad,TEntidadId>
    {
    }
}

