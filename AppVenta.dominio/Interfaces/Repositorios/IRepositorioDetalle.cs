using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.dominio.Interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad,TMovimientoId>:IAgregar<TEntidad>,ITransaccion
    {
    }
}
