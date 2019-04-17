using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockScraper.Models;
using StockScraper.Services;

namespace StockScraper.Controllers
{
    public class CurrentStockInfoesController : Controller
    {
        private StockInfoEntities db = new StockInfoEntities();

        // GET: CurrentStockInfoes
        public ActionResult Index()
        {
            return View(db.CurrentStockInfoes.ToList());
        }

        // GET: CurrentStockInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentStockInfo currentStockInfo = db.CurrentStockInfoes.Find(id);
            if (currentStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(currentStockInfo);
        }

      
        public ActionResult ScrapeYahooForCurrentInfo()
        {
            if (ModelState.IsValid)
            {
                WebDriver driver = new WebDriver();
                User yahooUser = new User();

                WebDriver.DriverLoginToPortfolioAndGetStockData();

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
