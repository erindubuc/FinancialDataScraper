using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class TestClass
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
            public void OpenDriverNavigateAndLogin()
            {
                try
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");

                    // Instantiate driver object that goes to specified url
                    driver = new ChromeDriver(options);

                    driver.Navigate().GoToUrl(LoginUrl1);
                }
                catch (Exception e)
                {
                    Console.WriteLine("This URL can't be found." + e.Message);
                    driver.Quit();
                }

            }
        }
    }
}