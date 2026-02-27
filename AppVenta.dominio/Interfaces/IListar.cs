
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio.Interfaces
{
    public interface IListar<TEntidad,TEntidadId>
    {
        List<TEntidad> Listar();
        TEntidad selecionarPorId(TEntidadId entidad);
    }
}
