using System.Collections.Generic;

namespace HTMLagilityPackScraper
{
    partial class Program
    {
        public class Stock
        {
            public string CompanyName { get; set; }
            public string Symbol { get; set; } 
            public string Price { get; set; }
            public string Change { get; set; }

            public Stock()
            { }

            public Stock(string companyName, string symbol, string price, string change)
            {
                this.CompanyName = companyName;
                this.Symbol = symbol;
                this.Price = price;
                this.Change = change;
            }

            public List<Stock> GetStocks()
            {
                var stockList = new List<Stock>();
                return stockList;
            }
        }
    }
}
