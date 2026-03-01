using AppVenta.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.infraestructura.datos.Configs
{
    internal class VentaDetalleConfig : IEntityTypeConfiguration<dominio.VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("VentaDetalles");
            builder.HasKey(vd => new { vd.productoId, vd.ventaId });
            builder.HasOne(detalle => detalle.producto).WithMany(producto =>producto.ventaDetalles );

            builder.HasOne(detalle => detalle.venta).WithMany(venta => venta.ventaDetalles);

        }
    }
}
