using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;

namespace HTMLagilityPackScraper
{
    partial class Program
    {
        static void Main(string[] args)
        {

            var html = @"https://money.cnn.com/data/hotstocks/index.html";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            //var bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body/div[contains(@id, 'cnnBody')]");

            var bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//table");
            var tableDataNodes = htmlDoc.DocumentNode.SelectNodes("//table[contains(@class, 'wsod_dataTable')]//tr//td//span");

            foreach (var node in tableDataNodes)
                Console.WriteLine(node.InnerHtml);

            Console.WriteLine();
            
            //var rowNodes = bodyNode.Elements("tr");
            var dataNodes = bodyNode.ChildNodes;

            foreach (var node in dataNodes)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    Console.WriteLine(node.InnerHtml);
                }
            }
            Console.ReadLine();

        }



        /*
         * Trying with Google Finance ---------------------------------->
         * 
        HtmlWeb web = new HtmlWeb();

        HtmlDocument htmlDoc = web.Load(FinanceUrl);


        if (htmlDoc.DocumentNode != null &&
            htmlDoc.ParseErrors != null &&
            !htmlDoc.ParseErrors.Any())
        {
            Console.WriteLine("Node found");
        }

        var tableRows = htmlDoc.DocumentNode.SelectNodes("//tbody/td").ToList();
        foreach (var row in tableRows)
            Console.WriteLine(" " + row.InnerHtml);

        var symbols = htmlDoc.DocumentNode.SelectNodes("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div/g-link/a/div/span/span");
        var prices = htmlDoc.DocumentNode.SelectNodes("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div/g-link/a/div/span/span/span");
        var changes = htmlDoc.DocumentNode.SelectNodes("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div/g-link/a/div/span/span/span/span");

        var companyNames = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div[1]/g-link/a/div");
        HtmlNodeCollection childNodes = companyNames.ChildNodes;   

        //'knowledge-finance-wholepage__financial-entities-list > div:nth-child(1) > g-link > a > div > span.z4Fov
        /*
        //*[@id="knowledge-finance-wholepage__financial-entities-list"]/div[2]/g-link/a/div/span[1]
        Console.WriteLine("CompanyName: " + companyNames);

        var symbols = htmlDoc.DocumentNode.SelectNodes("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div[1]/g-link/a/div/span[2]/span[1]");
        Console.WriteLine("Symbol: " + symbols);

        var prices = htmlDoc.DocumentNode.SelectNodes("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div[1]/g-link/a/div/span[2]/span[2]/span[1]");
        Console.WriteLine("Price: " + prices);

        var changes = htmlDoc.DocumentNode.SelectNodes("//*[@id='knowledge - finance - wholepage__financial - entities - list']/div[1]/g-link/a/div/span[2]/span[3]/span[2]/span");
        Console.WriteLine("Change: " + changes);

        List<Stock> ListOfStocks = new List<Stock>();

        */

        static string URLRequest(string url)
        {
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
                return responseFromServer;

            }

            // Close the response.  
            //response.Close();
        }
    }
}
