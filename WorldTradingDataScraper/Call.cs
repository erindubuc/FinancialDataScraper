using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTradingDataScraper
{
    public class Call 
    {
        public string Symbol { get; set; }
        public string PercentChange { get; set; }
        public string AvgVolume { get; set; }
        public string LastPrice { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string YearWeekHigh { get; set; }
        public string YearWeekLow { get; set; }

        public Call()
        {

        }

        public Call(string symbol, string percentChange, string avgVolume,
            string last, string open, string high, string low,
            string yearWeekHigh, string yearWeekLow)
        {
            this.Symbol = symbol;
            this.PercentChange = percentChange;
            this.AvgVolume = avgVolume;
            this.LastPrice = last;
            this.OpenPrice = open;
            this.HighPrice = high;
            this.LowPrice = low;
            this.YearWeekHigh = yearWeekHigh;
            this.YearWeekLow = yearWeekLow;
        }

        public List<Call> stockList;
       
    }
}

