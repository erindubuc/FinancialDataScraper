﻿using System;
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
            var symbol = "msft";
            var IEXTrading_API_PATH = "https://api.iextrading.com/1.0/stock/{0}/quote";

            IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, symbol);

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
                        Console.WriteLine("Open: " + companysInfo.open);
                        Console.WriteLine("Close: " + companysInfo.close);
                        Console.WriteLine("Low: " + companysInfo.low);
                        Console.WriteLine("High: " + companysInfo.high);
                        Console.WriteLine("52 Week Low: " + companysInfo.week52Low);
                        Console.WriteLine("52 Week High: " + companysInfo.week52High);
                    }
                }

            }

            Console.ReadLine();

        }

        public class CompanyInfoResponse
        {
            public string Symbol { get; set; }
            public string companyName { get; set; }
            public string primaryExchange { get; set; }
            public string sector { get; set; }
            public string calculationPrice { get; set; }
            public double open { get; set; }
            public long openTime { get; set; }
            public double close { get; set; }
            public long closeTime { get; set; }
            public double high { get; set; }
            public double low { get; set; }
            public double latestPrice { get; set; }
            public string latestSource { get; set; }
            public string latestTime { get; set; }
            public long latestUpdate { get; set; }
            public int latestVolume { get; set; }
            public string iexRealtimePrice { get; set; }
            public string iexRealtimeSize { get; set; }
            public string iexLastUpdated { get; set; }
            public double delayedPrice { get; set; }
            public long delayedPriceTime { get; set; }
            public double previousClose { get; set; }
            public int change { get; set; }
            public int changePercent { get; set; }
            public string iexMarketPercent { get; set; }
            public string iexVolume { get; set; }
            public int avgTotalVolume { get; set; }
            public string iexBidPrice { get; set; }
            public string iexBidSize { get; set; }
            public string iexAskPrice { get; set; }
            public string iexAskSize { get; set; }
            public long marketCap { get; set; }
            public double peRatio { get; set; }
            public double week52High { get; set; }
            public double week52Low { get; set; }
            public int ytdChange { get; set; }
        }
    }
}

