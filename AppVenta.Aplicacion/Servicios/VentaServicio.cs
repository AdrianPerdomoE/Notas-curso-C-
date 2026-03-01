using AppVenta.Aplicacion.Interfaces;
using AppVenta.dominio;
using AppVenta.dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Aplicacion.Servicios
{
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {
        private IRepositorioMovimiento<Venta, Guid> _repositorioVenta;
        private IRepositorioBase<Producto, Guid> _repositorioProducto;
        private IRepositorioDetalle<VentaDetalle, Guid> _repositorioVentaDetalle;

        public VentaServicio(IRepositorioMovimiento<Venta, Guid> repositorioVenta, IRepositorioBase<Producto, Guid> repositorioProducto, IRepositorioDetalle<VentaDetalle, Guid> repositorioVentaDetalle)
            {
                _repositorioVenta = repositorioVenta;
                _repositorioProducto = repositorioProducto;
                _repositorioVentaDetalle = repositorioVentaDetalle;
        }
        public Venta Agregar(Venta entidad)
        {
            if (entidad == null) throw new ArgumentNullException("La venta es requerida");
            var venta = _repositorioVenta.Agregar(entidad);
            entidad.ventaDetalles.ForEach(detalle =>
            {
                var productoSelecionado = _repositorioProducto.selecionarPorId(detalle.productoId);
                if (productoSelecionado == null ) throw new NullReferenceException("El producto no existe");
                var detalleNuevo = new VentaDetalle();
                detalleNuevo.ventaId = venta.Id;
                detalleNuevo.productoId = productoSelecionado.Id;
                detalleNuevo.costoUnitario = productoSelecionado.costo;
                detalleNuevo.precioUnitario = productoSelecionado.precio;
                detalleNuevo.cantidadVendida = detalle.cantidadVendida;
                detalleNuevo.subtotal = detalleNuevo.costoUnitario * detalleNuevo.cantidadVendida;
                detalleNuevo.impuesto = detalleNuevo.subtotal*(decimal)0.15;
                detalleNuevo.total = detalleNuevo.subtotal + detalleNuevo.impuesto;
                _repositorioVentaDetalle.Agregar( detalleNuevo);
                productoSelecionado.cantidadEnStock-= detalleNuevo.cantidadVendida;
                _repositorioProducto.Editar(productoSelecionado);
                entidad.subTotal = detalleNuevo.subtotal;
                entidad.impuesto = detalleNuevo.impuesto;
                entidad.total = detalleNuevo.total;
            });
            _repositorioVenta.GuardarCambios();
            return venta;
        }

        public void Anular(Guid id)
        {   
            _repositorioVenta.Anular(id);
        }

        public List<Venta> Listar()
        {
            return _repositorioVenta.Listar();
        }

        public Venta selecionarPorId(Guid id)
        {
           return _repositorioVenta.selecionarPorId(id);
        }

    }
}
