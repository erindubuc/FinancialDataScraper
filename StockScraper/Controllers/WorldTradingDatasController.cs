using RestSharp;
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
using Database = StockScraper.Services.Database;

namespace StockScraper.Controllers
{
    public class WorldTradingDatasController : Controller
    {
        private StockInfoEntities1 db = new StockInfoEntities1();

        // GET: WorldTradingDatas
        public ActionResult Index()
        {
            return View(db.WorldTradingDatas.ToList());
        }

        [Authorize]
        public ActionResult CallWTDApiForCurrentInfo()
        {
            if (ModelState.IsValid)
            {
                WorldTradingDataApi newCallToApi = new WorldTradingDataApi();
                var request = newCallToApi.MakeApiRequest();
                var response = newCallToApi.ReceieveApiResponse(request);

                List<CallForStockInfo> allStocks = new List<CallForStockInfo>();

                CallForStockInfo newStock;
                var callForStockInfo = newCallToApi.DeserializeResponse(response);

                for (int stockIndex = 0; stockIndex < WorldTradingDataApi.stocks.Count; stockIndex++)
                {
                    string symbol = callForStockInfo.data[stockIndex].symbol.ToString();
                    string price = callForStockInfo.data[stockIndex].price.ToString();
                    string price_open = callForStockInfo.data[stockIndex].price_open.ToString();
                    string day_high = callForStockInfo.data[stockIndex].day_high.ToString();
                    string day_low = callForStockInfo.data[stockIndex].day_low.ToString();
                    string change_pct = callForStockInfo.data[stockIndex].change_pct.ToString();
                    string volume_avg = callForStockInfo.data[stockIndex].volume_avg.ToString();

                    newStock = new CallForStockInfo(symbol, price, price_open, day_high, day_low,
                        change_pct, volume_avg);
                    allStocks.Add(newStock);
                    Database.MoveWorldTradingDataInfoToHistoryOfStocksTable(newStock);
                    Database.AddCurrentWorldTradingDataInfoIntoDatabase(newStock);
                }

            }
            return RedirectToAction("Index");
        }

        // GET: WorldTradingDatas/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldTradingData worldTradingData = db.WorldTradingDatas.Find(id);
            if (worldTradingData == null)
            {
                return HttpNotFound();
            }
            return View(worldTradingData);
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
