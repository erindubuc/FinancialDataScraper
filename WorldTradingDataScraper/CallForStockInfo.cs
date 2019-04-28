using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTradingDataScraper
{
    public class CallForStockInfo 
    {
        public string Symbol { get; set; }
        public string PercentChange { get; set; }
        public string AvgVolume { get; set; }
        public string Price { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }

        public CallForStockInfo()
        {

        }
        // values need to be in order they come in from response
        public CallForStockInfo(string symbol, string price, string price_open, string day_high, 
            string day_low, string change_pct, string volume_avg)
        {
            this.Symbol = symbol;
            this.PercentChange = change_pct;
            this.AvgVolume = volume_avg;
            this.Price = price;
            this.OpenPrice = price_open;
            this.HighPrice = day_high;
            this.LowPrice = day_low;
        }

        public void DisplayStockInfoToConsole(CallForStockInfo newStock)
        {
            Console.WriteLine($"Symbol: {newStock.Symbol}");
            Console.WriteLine($"Price: ${newStock.Price}");
            Console.WriteLine($"Open Price: ${newStock.OpenPrice}");
            Console.WriteLine($"High Price: ${newStock.HighPrice}");
            Console.WriteLine($"Low Price: ${newStock.LowPrice}");
            Console.WriteLine($"Percent Change: {newStock.PercentChange}%");
            Console.WriteLine($"Average Volume: {newStock.AvgVolume}");
            Console.WriteLine();
        }
 
    }
}

