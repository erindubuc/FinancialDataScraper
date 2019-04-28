using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTradingDataScraper
{

    [TestFixture]
    public class RestSharpTests
    {

        private string _api_token = "az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm";

        public string Api_token { get => _api_token; set => _api_token = value; }

        string[] symbol = { "aapl", "jnj", "nflx", "cvx", "googl", "fb",
                "amzn", "dis", "sbux", "tgt" };

        [Test]
        public void GetRequestToApiWithoutToken_FailureMessage()
        {
            const string BaseUrl = "https://www.worldtradingdata.com/api/v1/stock";
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri(BaseUrl);

            RestRequest restRequest = new RestRequest("aapl", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);
            string response = restClient.Execute(restRequest).Content;

            if (response.Contains("aapl"))
            {
                Assert.Fail("Whether information is not displayed");
            }
        }

        [Test]
        public void ConsumeApi_GetStockData()
        {
            const string BaseUrl = "https://www.worldtradingdata.com/api/v1/stock";
            
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri(BaseUrl);
            
            RestRequest restRequest = new RestRequest("?symbol={0}&api_token={_api_token}", Method.GET);
            for (int stockIndex = 0; stockIndex < symbol.Length; stockIndex++)
                restRequest.AddParameter("symbol", symbol[stockIndex], ParameterType.UrlSegment);

            restRequest.AddParameter("api_token", _api_token, ParameterType.UrlSegment);

            IRestResponse restResponse = restClient.Execute(restRequest);
            string response = restClient.Execute(restRequest).Content;


            Assert.IsNotEmpty("symbol");
            
        }

        [Test]
        public RestResponse MakeRequestAndGetResponse(IRestRequest _request)
        {
            const string BaseUrl = "https://www.worldtradingdata.com/";

            RestClient _client = new RestClient();
            _client.BaseUrl = new Uri(BaseUrl);

            if (_request == null)
            {
                throw new ArgumentNullException(nameof(_request));
            }

            _request = new RestRequest("api/v1/stock", Method.GET);
            _request.AddParameter("symbol", symbol, ParameterType.UrlSegment);
            _request.AddParameter("api_token", Api_token, ParameterType.UrlSegment);
            IRestResponse response = _client.Execute(_request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var worldTradingDataException = new ApplicationException(message, response.ErrorException);
                throw worldTradingDataException;
            }
            return (RestResponse)response;
        }

        [Test]
        public void GetResponse()
        {
            string[] symbol = { "aapl", "jnj", "nflx", "cvx", "googl", "fb",
                "amzn", "dis", "sbux", "tgt" };

            string BaseUrl = "https://www.worldtradingdata.com/api/v1/stock";
            string _api_token = "az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm";
            IRestClient client = new RestClient(BaseUrl);

            IRestRequest request = new RestRequest("?symbol={symbol}&api_token={_api_token}", Method.GET);
            request.AddParameter("symbol", symbol, ParameterType.UrlSegment);
            request.AddParameter("api_token", _api_token, ParameterType.UrlSegment);

            var response = client.Get<CallForStockInfo>(request);
            //var stockInfo = JsonConvert.DeserializeObject<CallForStockInfo>(response.Content);
            Assert.IsNotNull(response);
        }

        [Test]
        public void PrintResponseToConsole()
        {
            {
                List<string> stocks = new List<string>() { "aapl", "jnj", "nflx", "dis", "tgt" };
                string symbolInput = string.Join(",", stocks);

                string BaseUrl = "https://www.worldtradingdata.com/api/v1/stock";
                string api_token = "az2kDCRFHlJQyJXEcvPoIYjNPsPf62t4ZzF3a51r5uml71c4WbzAjTbDAKkm";
                var client = new RestClient(BaseUrl);

                var request = new RestRequest("?symbol={symbol}&api_token={api_token}", Method.GET);
                request.AddParameter("symbol", symbolInput);
                request.AddParameter("api_token", api_token);

                var response = client.Execute(request);
                Console.WriteLine(response.Content);
                Assert.IsNotEmpty(response.Content);

            }
        }
    }
}

