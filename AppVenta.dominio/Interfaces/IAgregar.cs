using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio.Interfaces
{
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad tentidad);
    }
}
