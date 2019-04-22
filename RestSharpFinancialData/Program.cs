using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFinancialData
{
    public class Program
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
                            Console.WriteLine("Company Name: " + companysInfo.CompanyName);
                            Console.WriteLine("Symbol: " + companysInfo.Symbol);
                            Console.WriteLine("Percent Change: " + companysInfo.ChangePercent);
                            Console.WriteLine("Average Volume: " + companysInfo.AvgTotalVolume);
                            Console.WriteLine("Last: " + companysInfo.LatestPrice);
                            Console.WriteLine("Open: " + companysInfo.Open);
                            Console.WriteLine("High: " + companysInfo.High);
                            Console.WriteLine("Low: " + companysInfo.Low);
                            Console.WriteLine("52 Week High: " + companysInfo.Week52High);
                            Console.WriteLine("52 Week Low: " + companysInfo.Week52Low);
                            Database.AddCurrentStockInfoIntoDatabase(companysInfo);
                        }
                    }
                }
            

            }

            Console.ReadLine();

        }
       
    }
}

