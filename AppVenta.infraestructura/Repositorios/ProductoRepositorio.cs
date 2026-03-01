using AppVenta.dominio;
using AppVenta.dominio.Interfaces.Repositorios;
using AppVenta.infraestructura.datos.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.infraestructura.datos.Repositorios
{
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private VentaContexto _db;

        public ProductoRepositorio(VentaContexto ventaDb)
        {
            _db = ventaDb;
        }
        public Producto Agregar(Producto entidad)
        {
            entidad.Id = Guid.NewGuid();
            _db.Productos.Add(entidad);
           return entidad;
        }

        public void Editar(Producto entidad)
        {
            var producto = _db.Productos.Where(p=>p.Id == entidad.Id).FirstOrDefault();
            if (producto != null)
            {   
                producto.nombre = entidad.nombre;
                producto.descripcion = entidad.descripcion;
                producto.costo = entidad.costo;
                producto.precio = entidad.precio;
                producto.cantidadEnStock = entidad.cantidadEnStock;
                _db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
        }

        public void Eliminar(Guid entidadId)
        {
            var producto = _db.Productos.Where(p => p.Id == entidadId).FirstOrDefault();
            if (producto != null)
            {
                _db.Productos.Remove(producto);
            }
        }

        public void GuardarCambios()
        {
            _db.SaveChanges();
        }

        public List<Producto> Listar()
        {
           return  _db.Productos.ToList();
        }

        public Producto selecionarPorId(Guid entidad)
        {
            var producto = _db.Productos.Where(p => p.Id == entidad).FirstOrDefault();
            return producto;
        }
    }
}
