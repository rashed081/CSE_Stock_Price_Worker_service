using CSEData.Scrapper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Scrapper
{
    public class StockDbContext : DbContext, IStockDbContext
    {

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public StockDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(optionsBuilder);
        }
        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Price> Prices { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
