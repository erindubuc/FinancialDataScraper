using System.Collections.Generic;


namespace HTMLagilityPackScraper
{

    public class Stock
    {
        public int StockId { get; set; }
        public string CompanyName { get; set; }
        public string Price { get; set; }
        public string Change { get; set; }
        public string PercentChange { get; set; }


        public Stock()
        { }

        public Stock(int stockId, string companyName, string price, string change, string percentChange)
        {
            this.CompanyName = companyName;
            this.Price = price;
            this.Change = change;
            this.PercentChange = percentChange;
        }

        public List<Stock> GetStocks()
        {
            var stockList = new List<Stock>();
            return stockList;
        }
    }
    
}
