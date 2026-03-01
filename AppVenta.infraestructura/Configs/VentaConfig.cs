using AppVenta.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.infraestructura.datos.Configs
{
    internal class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
           builder.ToTable("tblVentas");
            builder.HasKey(x => x.Id);
            builder.HasMany(venta => venta.ventaDetalles).WithOne(ventaDetalle => ventaDetalle.venta);
        }
    }
}
