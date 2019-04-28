using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTradingDataScraper
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
            WorldTradingDataApi newCallToApi = new WorldTradingDataApi();
            var request = newCallToApi.MakeApiRequest();
            var response = newCallToApi.ReceieveApiResponse(request);

            List<CallForStockInfo> allStocks = new List<CallForStockInfo>();

            CallForStockInfo newStock;

            var callForStockInfo = newCallToApi.DeserializeResponse(response);

            for (int stockIndex = 0; stockIndex < WorldTradingDataApi.stocks.Count; stockIndex++)
            {
                string symbol = callForStockInfo.data[stockIndex].symbol.ToString();
                string price = callForStockInfo.data[stockIndex].price.ToString();
                string price_open = callForStockInfo.data[stockIndex].price_open.ToString();
                string day_high = callForStockInfo.data[stockIndex].day_high.ToString();
                string day_low = callForStockInfo.data[stockIndex].day_low.ToString();
                string change_pct = callForStockInfo.data[stockIndex].change_pct.ToString();
                string volume_avg = callForStockInfo.data[stockIndex].volume_avg.ToString();

                newStock = new CallForStockInfo(symbol, price, price_open, day_high, day_low,
                    change_pct, volume_avg);
                allStocks.Add(newStock);
                newStock.DisplayStockInfoToConsole(newStock);
                Database.AddCurrentStockInfoIntoDatabase(newStock);
            }
            
            Console.ReadLine();










        }

    }
}
/*      
        string data = @" {
                    'symbol': 'AAPL',
                    'name': 'Apple Inc.',
                    'currency': 'USD',
                    'price': '204.30',
                    'price_open': '204.90',
                    'day_high': '205.00',
                    'day_low': '202.12',
                    '52_week_high': '233.47',
                    '52_week_low': '142.00',
                    'day_change': '-0.98',
                    'change_pct': '-0.48',
                    'close_yesterday': '205.28',
                    'market_cap': '963331686400',
                    'volume': '18276381',
                    'volume_avg': '22515757',
                    'shares': '4715279872',
                    'stock_exchange_long': 'NASDAQ Stock Exchange',
                    'stock_exchange_short': 'NASDAQ',
                    'timezone': 'EDT',
                    'timezone_name': 'America/New_York',
                    'gmt_offset': '-14400',
                    'last_trade_time': '2019-04-26 16:00:01'
                }";
     
     */


