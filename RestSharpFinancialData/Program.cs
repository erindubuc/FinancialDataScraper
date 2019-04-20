using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFinancialData
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] symbol = { "aapl", "jnj", "nflx", "cvx", "googl", "fb",
                "amzn", "dis", "sbux", "tgt" };
            
            


            for(int symbolsIndex = 0; symbolsIndex < symbol.Length; symbolsIndex++)
            {
                var IEXTrading_API_PATH = "https://api.iextrading.com/1.0/stock/{0}/quote";

                IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, symbol[symbolsIndex]);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //For IP-API
                    client.BaseAddress = new Uri(IEXTrading_API_PATH);
                    HttpResponseMessage response = client.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var companysInfo = response.Content.ReadAsAsync<CompanyInfoResponse>().GetAwaiter().GetResult();
                        if (companysInfo != null)
                        {
                            Console.WriteLine("Company Name: " + companysInfo.companyName);
                            Console.WriteLine("Symbol: " + companysInfo.symbol);
                            Console.WriteLine("Percent Change: " + companysInfo.changePercent);
                            Console.WriteLine("Average Volume: " + companysInfo.avgTotalVolume);
                            Console.WriteLine("Last: " + companysInfo.latestPrice);
                            Console.WriteLine("Open: " + companysInfo.open);
                            Console.WriteLine("High: " + companysInfo.high);
                            Console.WriteLine("Low: " + companysInfo.low);
                            Console.WriteLine("52 Week High: " + companysInfo.week52High);
                            Console.WriteLine("52 Week Low: " + companysInfo.week52Low);

                        }
                    }
                }
            

            }

            Console.ReadLine();

        }

        public class CompanyInfoResponse
        {
            public string symbol { get; set; }
            public string companyName { get; set; }
            public string primaryExchange { get; set; }
            public string sector { get; set; }
            public string calculationPrice { get; set; }
            public string open { get; set; }
            //public long openTime { get; set; }
            //public double close { get; set; }
            //public long closeTime { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string latestPrice { get; set; }
            //public string latestSource { get; set; }
            //public string latestTime { get; set; }
            //public long latestUpdate { get; set; }
            //public int latestVolume { get; set; }
            public string iexRealtimePrice { get; set; }
            public string iexRealtimeSize { get; set; }
            public string iexLastUpdated { get; set; }
            //public double delayedPrice { get; set; }
            //public long delayedPriceTime { get; set; }
            //public double previousClose { get; set; }
            public string change { get; set; }
            public string changePercent { get; set; }
            public string iexMarketPercent { get; set; }
            public string iexVolume { get; set; }
            public string avgTotalVolume { get; set; }
            //public string iexBidPrice { get; set; }
            //public string iexBidSize { get; set; }
            //public string iexAskPrice { get; set; }
            //public string iexAskSize { get; set; }
            //public long marketCap { get; set; }
            //public double peRatio { get; set; }
            public string week52High { get; set; }
            public string week52Low { get; set; }
            //public int ytdChange { get; set; }
        }
        /*
        public class StockSymbols
        {
            public string Symbol { get; set;}
            List<StockSymbols> GetStockSymbols()
            {
                public Symbol(string stockSymbol)
                {
                    this.Symbol = stockSymbol;
                }
                List<StockSymbols> stockSymbols = new List<StockSymbols>()
                {
                    stockSymbols.Add(new StockSymbols() { });
                    stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
                stockSymbols.Add();
            };
                
                , );
                return stockSymbols;
            }
        }
        */
    }
}

