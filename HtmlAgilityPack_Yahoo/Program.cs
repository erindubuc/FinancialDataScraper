using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAgilityPack_Yahoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebDriver driver = new WebDriver();
            User user = new User();

            WebDriver.DriverLoginToPortfolioAndGetStockData();

            
            //var web = new HtmlWeb();
            //var doc = web.Load(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(User.StockPortfolio);

            string name = htmlDoc.DocumentNode
                .SelectSingleNode("//td/input")
                .Attributes["value"].Value;

            Console.ReadLine();
        }
    }
}
