﻿using System;
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

        // GET: HistoryOfStockInfoes
        public ActionResult Index(string sortOrder)
        {
            ViewBag.SymbolSortParm = String.IsNullOrEmpty(sortOrder) ? "symbol_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var historyOfStockInfoes = db.HistoryOfStockInfoes.Include(h => h.CurrentStockInfo);

            switch (sortOrder)
            {
                case "symbol_desc":
                    historyOfStockInfoes = db.HistoryOfStockInfoes.OrderByDescending(s => s.Symbol);
                   break;
                case "Date":
                    historyOfStockInfoes = db.HistoryOfStockInfoes.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    historyOfStockInfoes = db.HistoryOfStockInfoes.OrderByDescending(s => s.Date);
                    break;
                default:
                    historyOfStockInfoes = db.HistoryOfStockInfoes.Include(h => h.CurrentStockInfo);
                    //students = students.OrderBy(s => s.LastName);
                    break;
            }

            return View(historyOfStockInfoes.ToList());
        }

        // GET: HistoryOfStockInfoes/Details/5
        public ActionResult Details(byte? id, DateTime date)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryOfStockInfo historyOfStockInfo = db.HistoryOfStockInfoes.Find(id, date);
            if (historyOfStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(historyOfStockInfo);
        }

        // GET: HistoryOfStockInfoes/Create
        public ActionResult Create()
        {
            ViewBag.Symbol = new SelectList(db.CurrentStockInfoes, "Symbol", "PercentChange");
            return View();
        }

        // POST: HistoryOfStockInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockId,Symbol,PercentChange,AverageVolume,LastPrice,MarketTime,OpenPrice,HighPrice,LowPrice,YearWeekHigh,YearWeekLow,Date")] HistoryOfStockInfo historyOfStockInfo)
        {
            if (ModelState.IsValid)
            {
                db.HistoryOfStockInfoes.Add(historyOfStockInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Symbol = new SelectList(db.CurrentStockInfoes, "Symbol", "PercentChange", historyOfStockInfo.Symbol);
            return View(historyOfStockInfo);
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
