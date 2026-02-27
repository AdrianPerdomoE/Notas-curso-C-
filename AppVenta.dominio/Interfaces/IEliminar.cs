using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio.Interfaces
{
    public interface IEliminar<TEntidadId>
    {
        void Eliminar( TEntidadId entidadId);
    }
}
