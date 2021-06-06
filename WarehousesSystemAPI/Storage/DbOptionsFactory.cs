using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousesSystemAPI.Models;

namespace WarehousesSystemAPI.IntegrationTests
{
    public static class DbOptionsFactory
    {
        private static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=WarehousesDb;Trusted_Connection=True;";
        static DbOptionsFactory()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptions = new DbContextOptionsBuilder<SqlServerContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public static DbContextOptions<SqlServerContext> DbContextOptions { get; }

    }
}
