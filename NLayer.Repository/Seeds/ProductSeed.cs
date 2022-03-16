using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using NLayer.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Kurşun Kalem", CategoryId = 1, Price = 5, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 2, Name = "Güzel Yazı Defteri", CategoryId = 2, Price = 15, Stock = 10, CreatedDate = DateTime.Now },
                new Product { Id = 3, Name = "Almanca Dil Bilgisi Kitabı", CategoryId = 3, Price = 90, Stock = 10, CreatedDate = DateTime.Now });
        }
    }
}
