using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace WorldTradingDataScraper
{
  
    public class WorldTradingDataApi : CallForStockInfo
    {
        
        //api/v1/stock?symbol=AAPL,MSFT,HSBA.L&api_token=az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm

        string _api_token = "az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm";

        public string Api_token { get => _api_token; set => _api_token = value; }
        public WorldTradingDataApi()
        {
           
        }

        //?symbol={0}&api_token={_api_token}

        public CallForStockInfo DeserializeResponse(RestResponse response)
        {
            return JsonConvert.DeserializeObject<CallForStockInfo>(response.Content);
        }

    }

}
