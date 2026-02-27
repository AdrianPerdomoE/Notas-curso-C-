using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio.Interfaces
{
    public interface IEditar<TEntidad>
    {
        void Editar(TEntidad entidad);
    }
}
