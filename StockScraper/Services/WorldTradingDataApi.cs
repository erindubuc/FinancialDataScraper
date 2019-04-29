using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockScraper.Services
{
    public class WorldTradingDataApi
    {
        public static List<string> stocks = new List<string>() { "aapl", "jnj", "nflx", "dis", "tgt" };
        public static string symbolInput = string.Join(",", stocks);
        public static string BaseUrl = "https://www.worldtradingdata.com/api/v1/stock";
        IRestClient client;
        public WorldTradingDataApi()
        {

            client = new RestClient(BaseUrl);

        }

        public IRestRequest MakeApiRequest()
        {
            string api_token = "az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm";

            var request = new RestRequest("?symbol={symbol}&api_token={api_token}", Method.GET);
            request.AddParameter("symbol", symbolInput);
            request.AddParameter("api_token", api_token);
            return request;
        }
        public IRestResponse ReceieveApiResponse(IRestRequest request)
        {
            var response = client.Execute(request);
            return response;
            //Console.WriteLine(response.Content);
        }

        public dynamic DeserializeResponse(dynamic response)
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }
    }
}