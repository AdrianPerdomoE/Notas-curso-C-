using AppVenta.dominio;
using AppVenta.dominio.Interfaces.Repositorios;
using AppVenta.infraestructura.datos.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.infraestructura.datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {
       private VentaContexto _db;

        public VentaRepositorio(VentaContexto db)
        {
                _db = db;
        }
        public Venta Agregar(Venta tentidad)
        {
            tentidad.Id = Guid.NewGuid();
            _db.Ventas.Add(tentidad);
            return tentidad;
        }

        public void Anular(Guid id)
        {
           var venta = _db.Ventas.Where(v=> v.Id == id).FirstOrDefault();

            if (venta == null) throw new NullReferenceException("Esta intentado anular una venta que no existe");
            venta.anulado = true;
            _db.Entry(venta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarCambios()
        {
           _db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return _db.Ventas.ToList();
        }

        public Venta selecionarPorId(Guid entidad)
        {
            var venta = _db.Ventas.Where(v => v.Id == entidad).FirstOrDefault();
            return venta;
        }
    }
}
