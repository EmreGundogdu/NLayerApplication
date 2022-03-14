using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //bunu yazarsak diğer configurationları yazmamıza gerek yok çalıştığımız yerdeki bütün configurationları getiricek ve uygulayacak

            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() { Id = 1, Color = "Kırmızı", Height = 100, Width = 200, ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Mavi", Width = 50, Height = 200, ProductId = 2 });
        }
    }
}
