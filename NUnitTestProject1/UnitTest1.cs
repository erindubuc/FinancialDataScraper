using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;   
        private string LoginUrl = "https://login.yahoo.com/";
        private string username = "avengersassembull";
        private string password = "Ready2rock";
        private static string stockPortfolioUrl = "https://finance.yahoo.com/portfolio/p_2/view/view_1";
        public static List<IWebElement> stockInfo;

        public static string StockPortfolio { get => stockPortfolioUrl; set => stockPortfolioUrl = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string LoginUrl1 { get => LoginUrl; set => LoginUrl = value; }

        [Test]
        public void StartDriverAndGoToYahoo()
        {
            driver.Navigate().GoToUrl("https://login.yahoo.com/");
            Assert.AreNotEqual("Yahoo", driver.Title);
            driver.Close();
            driver.Quit();
        }


        [Test]
        public void OpenDriverNavigateAndLogin()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                
                driver = new ChromeDriver(@"C:\Users\Erin\source\repos\erindubuc\FinancialDataScraper\NUnitTestProject1", options);

                driver.Navigate().GoToUrl(LoginUrl1);
            }
            catch (Exception e)
            {
                Console.WriteLine("This URL can't be found." + e.Message);
                driver.Quit();
            }

            try
            {
                // Driver finds login textbox, enters username, and presses enter
                driver.FindElement(By.Id("login-username")).SendKeys(Username + Keys.Enter);

                // Driver waits for browser to load password page
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);

            }
            try
            {
                // Driver finds password textbox, enters password, and presses enter 
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);

            }
        }

        [Test]
        public void DriverLoginPortfolioAndGetData()
        {
            try
            {
                driver.Navigate().GoToUrl(LoginUrl1);
            }
            catch (Exception e)
            {
                Console.WriteLine("This URL can't be found." + e.Message);
                driver.Quit();
            }
            try
            {
                // Driver finds login textbox, enters username, and presses enter
                driver.FindElement(By.Id("login-username")).SendKeys(Username + Keys.Enter);

                // Driver waits for browser to load password page
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);

            }
            try
            {
                // Driver finds password textbox, enters password, and presses enter 
                driver.FindElement(By.Id("login-passwd")).SendKeys(Password + Keys.Enter);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element can't be found." + e.Message);
                throw (e);

            }

            try
            {
                driver.Navigate().GoToUrl(StockPortfolio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find this site." + e.Message);
                throw e;
            }

            try
            {
                driver.FindElements(By.TagName("tr"));
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Table rows can't be found." + e.Message);
                throw e;
            }

            try
            {
                stockInfo = new List<IWebElement>(driver.FindElements(By.TagName("td")));
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find table data." + e.Message);
                throw e;
            }

        }
    }
}