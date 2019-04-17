using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockScraper.Models;

namespace StockScraper.Controllers
{
    public class HistoryOfStockInfoesController : Controller
    {
        private StockInfoEntities db = new StockInfoEntities();

        [Authorize]
        // GET: HistoryOfStockInfoes
        public ActionResult Index()
        {
            var historyOfStockInfoes = db.HistoryOfStockInfoes.Include(h => h.CurrentStockInfo);
            return View(historyOfStockInfoes.ToList());
        }

        // GET: HistoryOfStockInfoes/Details/5
        public ActionResult Details(byte? id, DateTime date)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryOfStockInfo historyStockInfo = db.HistoryOfStockInfoes.Find(id, date);
            if (historyStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(historyStockInfo);
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
