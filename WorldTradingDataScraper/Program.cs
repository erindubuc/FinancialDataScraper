using Newtonsoft.Json;
using RestSharp;
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

        static void Main(string[] args)
        {
            string[] symbol = { "aapl", "jnj", "nflx", "cvx", "googl", "fb",
                "amzn", "dis", "sbux", "tgt" };

            string BaseUrl = "https://www.worldtradingdata.com/api/v1/stock";
            string _api_token = "az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm";
            RestClient client = new RestClient(BaseUrl);

            RestRequest request = new RestRequest("?symbol={0}&api_token={}", Method.GET);
            request.AddParameter("symbol", symbol, ParameterType.UrlSegment);
            request.AddParameter("api_token", _api_token, ParameterType.UrlSegment);












        }
    }
}
/*
        restRequest.AddParameter("symbol", symbol[0], ParameterType.UrlSegment);

        restRequest.AddParameter("api_token", stockCall.Api_token, ParameterType.UrlSegment);


        IRestResponse restResponse = restClient.Execute(restRequest);
        string response = restClient.Execute(restRequest).Content;
        
        string data = @" {
                    'symbo': 'AAPL',
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


