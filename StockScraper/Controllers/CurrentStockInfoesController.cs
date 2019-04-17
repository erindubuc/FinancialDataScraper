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

        // GET: CurrentStockInfoes/Create
        public ActionResult Create()
        {
            return View();
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

        // POST: CurrentStockInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stock_Id,Symbol,PercentChange,AverageVolume,LastPrice,MarketTime,OpenPrice,HighPrice,LowPrice,YearWeekHigh,YearWeekLow,Date")] CurrentStockInfo currentStockInfo)
        {
            if (ModelState.IsValid)
            {
                db.CurrentStockInfoes.Add(currentStockInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currentStockInfo);
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
