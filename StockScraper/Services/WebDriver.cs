using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockScraper.Services
{
    public class WebDriver : User
    {
        public static ChromeOptions options;
        public static IWebDriver driver;
        public static List<Stock> ListOfAllStocks;

        public static List<Stock> DriverLoginToPortfolioAndGetStockData()
        {
            try
            {
                options = new ChromeOptions();
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");

                driver = new ChromeDriver(@"C:\Users\Erin\source\repos\erindubuc\FinancialDataScraper\NUnitTestProject1", options);
                driver.Navigate().GoToUrl(LoginUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine("This URL can't be found. " + e.Message);

                driver.Quit();
            }

            try
            {
                driver.FindElement(By.Id("login-username")).SendKeys(Username + Keys.Enter);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found. " + e.Message);

                throw e;
            }

            try
            {
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found. " + e.Message);

                throw e;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Timeout while entering password." + ex.Message);

                throw ex;
            }

            try
            {
                driver.Navigate().GoToUrl(StockPortfolio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find this site. " + e.Message);

                throw e;
            }

            try
            {
                IWebElement stockTable = driver.FindElement(By.TagName("tbody"));

                IList<IWebElement> tableRows = new List<IWebElement>(stockTable.FindElements(By.ClassName("simpTblRow")));

                ListOfAllStocks = new List<Stock>();

                int stockId = 0;

                foreach (var row in tableRows)
                {
                    stockId++;
                    string[] singleStockData = row.Text.Split(' ');
                    string[] stockSymbolAndPercent = singleStockData[0].Split(new[] { "\r\n", "\r", "\n" },
                            StringSplitOptions.None
                        );

                    singleStockData[0] = stockSymbolAndPercent[0];
                    
                    Stock newStock = new Stock(stockId, stockSymbolAndPercent[0], stockSymbolAndPercent[1], singleStockData[1], singleStockData[2],
                        singleStockData[3] + singleStockData[4], singleStockData[5], singleStockData[6], singleStockData[7],
                        singleStockData[8], singleStockData[9]);

                    ListOfAllStocks.Add(newStock);

                    Database.MoveCurrentStockInfoToHistoryOfStocksTable(newStock);
                    Database.AddCurrentStockInfoIntoDatabase(newStock);

                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Table rows can't be found. " + e.Message);

                throw e;
            }

            driver.Quit();

            return ListOfAllStocks;
        }
    }
}