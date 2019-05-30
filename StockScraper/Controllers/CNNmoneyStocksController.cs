using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockScraper.Models;
using Database = StockScraper.Services.Database;
using StockScraper.Services;

namespace StockScraper.Controllers
{
    public class CNNmoneyStocksController : Controller
    {
        private StockInfoEntities3 db = new StockInfoEntities3();
        [Authorize]
        // GET: CNNmoneyStocks
        public ActionResult Index()
        {
            return View(db.CNNmoneyStocks.ToList());
        }

        [Authorize]
        // GET: CNNmoneyStocks/Details/5
        public ActionResult HAPScrapeCNNHotStocks()
        {
            if (ModelState.IsValid)
            {
                string html = @"https://money.cnn.com/data/hotstocks/index.html";

                HtmlWeb web = new HtmlWeb();

                HtmlDocument htmlDoc = web.Load(html);

                List<Stock> stockList = new List<Stock>();

                HtmlNodeCollection rowsNodesList = htmlDoc.DocumentNode.SelectNodes("//table[contains(@class, 'wsod_dataTable')]//tr");

                int stockId = 1;
                foreach (var row in rowsNodesList)
                {
                    stockId++;

                    var cells = row.SelectNodes("td");
                    if (cells != null && cells.Count > 0)
                    {
                        var companyName = cells[0].InnerText;
                        var price = cells[1].InnerText;
                        var change = cells[2].InnerText;
                        var percentChange = cells[3].InnerText;


                        Stock newStock = new Stock(stockId, companyName, price, change, percentChange);
                        stockList.Add(newStock);
                        Database.AddCNNMoneyIntoDatabase(newStock);
                    }

                }
            }
            return RedirectToAction("Index");
        }



  
   

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
