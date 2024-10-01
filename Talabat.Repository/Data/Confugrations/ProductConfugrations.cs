using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.Repository.Data.Confugrations
{
    internal class ProductConfugrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e=>e.Brand)
                .WithMany()
                .HasForeignKey(e=>e.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e=>e.Category)
                .WithMany()
                .HasForeignKey(e=>e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.Price).HasColumnType("decimal(18,3)");
        }
    }
}
