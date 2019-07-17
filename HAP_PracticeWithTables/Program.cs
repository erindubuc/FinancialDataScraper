using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HAP_PracticeWithTables
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = "https://www.webscraper.io/test-sites/tables";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            //var nodes = htmlDoc.DocumentNode.SelectNodes("//tbody//tr//td");
            var firstNames = htmlDoc.DocumentNode.SelectNodes("/html/body/div/div/table/tbody[1]/tr/td[2]");
            var lastNames = htmlDoc.DocumentNode.SelectNodes("/html/body/div/div/table/tbody[1]//tr//td[3]");
            var rows = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/table[1]/tbody[1]//tr");


            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");
                if (cells != null & cells.Count > 0)
                {
                    //Console.WriteLine($"Row info: {row.InnerText}");
                    var firstName = cells[1].InnerText;
                    var lastName = cells[2].InnerText;
                    var username = cells[3].InnerText;

                    Console.WriteLine($"First: {firstName}  | Last: {lastName}  | Username: {username}");
                    Console.WriteLine("-----------------------------------------------");
                }
            }
            /*
            foreach (var node in firstNames)
                Console.WriteLine("FirstName: " + node.InnerHtml);
                */
            Console.ReadLine();
        }
    }
}
