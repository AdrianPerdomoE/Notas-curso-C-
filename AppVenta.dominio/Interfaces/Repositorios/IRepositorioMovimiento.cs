using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadId> : IAgregar<TEntidad>, IListar<TEntidadId,TEntidadId>, ITransaccion
    {
        void anular (TEntidad tentidad);
    }
}
