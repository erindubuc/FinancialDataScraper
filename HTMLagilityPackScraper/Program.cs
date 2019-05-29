using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;

namespace HTMLagilityPackScraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            string html = @"https://money.cnn.com/data/hotstocks/index.html";

            HtmlWeb web = new HtmlWeb();

            HtmlDocument htmlDoc = web.Load(html);

            List<Stock> stockList = new List<Stock>();

            HtmlNodeCollection rowsNodesList = htmlDoc.DocumentNode.SelectNodes("//table[contains(@class, 'wsod_dataTable')]//tr");

            //int rowCount = 1;
            int stockId = 0;

            foreach (var row in rowsNodesList)
            {
                stockId++;

                var cells = row.SelectNodes("td");
                if (cells != null && cells.Count > 0)
                {
                    
                    var companyName = cells[0].InnerText;
                    //companyName = companyName.Replace("\r\n", "").Trim();
                    var price = cells[1].InnerText;
                    //price = price.Replace("\r\n", "").Trim();
                    var change = cells[2].InnerText;
                    //change = change.Replace("\r\n", "").Trim();
                    var percentChange = cells[3].InnerText;
                    //percentChange = percentChange.Replace("\r\n", "").Trim();

                    Console.WriteLine("Row: {0}", stockId);
                    Console.WriteLine("Company Name: {0}", companyName);
                    Console.WriteLine("Price: {0}", price);
                    Console.WriteLine("Change: {0}", change);
                    Console.WriteLine("Percent Change: {0}", percentChange);
                    Console.WriteLine("--------------------");
                    //rowCount++;

                    Stock newStock = new Stock(stockId, companyName, price, change, percentChange);
                    stockList.Add(newStock);
                    Database.AddCurrentStockInfoIntoDatabase(newStock);
                }
            }
            // Help to parse for database from http://davidgiard.com/2018/06/20/UsingHTMLAgilityPackToParseAWebPage.aspx

        }
    }

}
