using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Scrapper
{
    public class Scraper: IScrapper
    {
        private const string Url = "https://www.cse.com.bd/market/current_price";
        private static readonly string[] Keys = { "companyid", "stockcode", "ltp", "open", "high", "low", "ycp", "trade", "value(mn)", "volume" };

        public async Task<List<Dictionary<string, string>>> GetCurrentPriceAsync()
        {
            List<Dictionary<string, string>> ParsedPriceData = new List<Dictionary<string, string>>();

            try
            {
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = await web.LoadFromWebAsync(Url);

                if (!IsMarketOpen(htmlDoc))
                {
                    Console.WriteLine("Market is closed.");
                    return ParsedPriceData;
                }

                ParsePriceData(htmlDoc, ParsedPriceData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return ParsedPriceData;
        }

        private bool IsMarketOpen(HtmlDocument htmlDoc)
        {
            var divMarketStatus = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'market_status')]");
            var spanElement = divMarketStatus?.SelectSingleNode(".//span");

            return spanElement != null && spanElement.InnerText.ToLower() == "open";
        }

        private void ParsePriceData(HtmlDocument htmlDoc, List<Dictionary<string, string>> ParsedPriceData)
        {
            var rows = htmlDoc.DocumentNode.SelectNodes("//table[contains(@id, 'dataTable')]//tbody//tr");

            if (rows == null)
                return;

            foreach (var row in rows)
            {
                var rowData = new Dictionary<string, string>();
                var cells = row.SelectNodes(".//td");

                if (cells != null && cells.Count == Keys.Length)
                {
                    for (int j = 0; j < cells.Count; j++)
                    {
                        rowData.Add(Keys[j], cells[j].InnerText.Trim());
                    }
                    ParsedPriceData.Add(rowData);
                }
            }
        }
    }
}
