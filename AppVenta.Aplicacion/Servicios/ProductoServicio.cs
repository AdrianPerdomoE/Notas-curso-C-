using AppVenta.Aplicacion.Interfaces;
using AppVenta.dominio;
using AppVenta.dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Aplicacion.Servicios
{
    public class ProductoServicio : IservicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> _repositorio;
        public ProductoServicio(IRepositorioBase<Producto, Guid> repositorio)
        {
            _repositorio = repositorio;
        }   
        public Producto Agregar(Producto tentidad)
        {
            if (tentidad == null)
            {
                throw new ArgumentNullException("El producto es requerido");
            }
            var resultProducto = _repositorio.Agregar(tentidad);
            _repositorio.GuardarCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null) throw new ArgumentNullException("El producto es requerido para editar");
            var productoExistente = _repositorio.selecionarPorId(entidad.Id);
            _repositorio.GuardarCambios();
        }

        public void Eliminar(Guid entidadId)
        {   
            _repositorio.Eliminar(entidadId);
            _repositorio.GuardarCambios();
        }

        public List<Producto> Listar()
        {
            return _repositorio.Listar();
        }

        public Producto selecionarPorId(Guid entidad)
        {   return _repositorio.selecionarPorId(entidad);
        }
    }
}
