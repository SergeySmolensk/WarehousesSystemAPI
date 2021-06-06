using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace WarehousesSystemAPI.Models
{
    public class SqlServerContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<ManufacturyEntity> Manufactures { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<WarehouseContentsEntity> WarehouseContents { get; set; }

        public DbSet<WarehouseEntity> Warehouses { get; set; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CountryEntity>().HasData(new List<CountryEntity>
            {
                new CountryEntity
                {
                    Id = 1,
                    Country = "Russia"
                },
                new CountryEntity
                {
                    Id = 2,
                    Country = "Ukraine"
                },
                new CountryEntity
                {
                    Id = 3,
                    Country = "Belarus"
                }
            });
            modelBuilder.Entity<WarehouseEntity>().HasData(new List<WarehouseEntity>
            {
                new WarehouseEntity
                {
                    Id = 1,
                    WarehouseName = "WarehouseOne"
                },
                new WarehouseEntity
                {
                   Id = 2,
                   WarehouseName = "WarehouseTwo"
                },
                new WarehouseEntity
                {
                    Id = 3,
                    WarehouseName = "WarehouseThree"
                }
            });

            modelBuilder.Entity<ManufacturyEntity>().HasData(new List<ManufacturyEntity>
            {
                new ManufacturyEntity
                {
                    Id = 1,
                    ManufactureName = "ManufactureOne"
                },
                new ManufacturyEntity
                {
                   Id = 2,
                   ManufactureName = "ManufactureTwo"
                },
                new ManufacturyEntity
                {
                    Id = 3,
                    ManufactureName = "ManufactureThree"
                }
            });

            modelBuilder.Entity<WarehouseContentsEntity>().HasKey(k => new { k.ProductId, k.WarehouseId });
        }
    }
}
