namespace RestSharpFinancialData
{
    public partial class Program
    {
        public class CompanyInfoResponse
        {
            public string Symbol { get; set; }
            public string CompanyName { get; set; }
            public string Open { get; set; }
            public string High { get; set; }
            public string Low { get; set; }
            public string LatestPrice { get; set; }
            public string ChangePercent { get; set; }
            public string AvgTotalVolume { get; set; }
            public string Week52High { get; set; }
            public string Week52Low { get; set; }
        }
       
    }
}

