using CSEData.Scrapper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Scrapper
{
    public class DatabaseManager
    {
        private readonly IStockDbContext _dbContext;

        public DatabaseManager(IStockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void StoreStockData(List<Dictionary<string, string>> scrapedDataList)
        {
            foreach (var scrapedData in scrapedDataList)
            {
                if (scrapedData != null)
                {
                    var companyId = Convert.ToInt32(scrapedData["companyid"]);

                    var company = _dbContext.Companies.FirstOrDefault(x => x.StockCodeName == scrapedData["stockcode"]);
                    if (company != null)
                    {
                        var stocks = _dbContext.Prices.Where(b => b.companyId == company.id).ToList();
                        var newStock = new Price
                        {
                            //id = company.Id,
                            LTP = Convert.ToDouble(scrapedData["ltp"]),
                            volume = int.Parse(scrapedData["volume"]),
                            open = Convert.ToDouble(scrapedData["open"]),
                            high = Convert.ToDouble(scrapedData["high"]),
                            low = Convert.ToDouble(scrapedData["low"]),
                            time = DateTime.Now
                        };
                        stocks.Add(newStock);
                        company.priceList = stocks;
                        _dbContext.Prices.Add(newStock);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var newCompany = new Company
                        {
                            //Id = companyId,
                            StockCodeName = scrapedData["stockcode"]
                        };

                        var newStock = new Price
                        {
                            //CompanyId = company.Id,
                            LTP = Convert.ToDouble(scrapedData["ltp"]),
                            volume = int.Parse(scrapedData["volume"]),
                            open = Convert.ToDouble(scrapedData["open"]),
                            high = Convert.ToDouble(scrapedData["high"]),
                            low = Convert.ToDouble(scrapedData["low"]),
                            time = DateTime.Now
                        };
                        newCompany.priceList = new List<Price>();
                        newCompany.priceList?.Add(newStock);
                        _dbContext.Companies.Add(newCompany);
                        _dbContext.SaveChanges();
                    }
                }
            }
            //Console.WriteLine("Insertion done");

        }
    }
}
