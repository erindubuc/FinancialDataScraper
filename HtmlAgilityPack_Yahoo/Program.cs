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

            WebDriver.DriverLoginToPortfolio();

            //var html = @"https://finance.yahoo.com/portfolio/p_2/view/view_2";
            var html = User.StockPortfolio;
            //var web = new HtmlWeb();

            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(html);
            //htmlDoc.LoadHtml(User.StockPortfolio);

            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[1]/a
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[2]/span
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[3]
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[4]/span
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[5]/span
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[6]
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[7]
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[8]
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[9]/span
            //*[@id="pf-detail-table"]/div[1]/table/tbody/tr[1]/td[10]/span

            //IWebElement stockTable = driver.FindElement(By.TagName("tbody"));

            //IList<IWebElement> tableRows = new List<IWebElement>(stockTable.FindElements(By.ClassName("simpTblRow")));
            var table = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='pf - detail - table']/div[1]/table/tbody");
            Console.WriteLine(table.OuterHtml);


           /*
            foreach (var row in rowNodesList)
            {
                var cells = row.SelectNodes("td");
                if (cells != null && cells.Count > 0)
                {
                    var companySymbol = cells[0].InnerText;
                    var percentChange = cells[1].InnerText;

                    Console.WriteLine("Symbol: {0}", companySymbol);
                    Console.WriteLine("Percent Change: {0}", percentChange);
                    Console.WriteLine("-------------------------");
                }
            }
            */

            Console.ReadLine();
        }
    }
}
