using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.dominio.Interfaces;
namespace AppVenta.dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad,TEntidadId>: IAgregar<TEntidad>, IEliminar<TEntidadId>, IEditar<TEntidad>, IListar<TEntidad,TEntidadId>, ITransaccion
    {

    }
}
