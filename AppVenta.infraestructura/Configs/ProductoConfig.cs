using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AppVenta.infraestructura.datos.Configs
{
    internal class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(p => p.Id);

            builder.HasMany(producto => producto.ventaDetalles).WithOne(ventaDetalle => ventaDetalle.producto);
        }
    }
}
