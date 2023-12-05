using CSEData.Scrapper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Scrapper
{
    public interface IStockDbContext
    {
        DbSet<Price> Prices { get; set; }
        DbSet<Company> Companies { get; set; }
        int SaveChanges();
    }
}
