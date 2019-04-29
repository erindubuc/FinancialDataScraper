//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockScraper.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorldTradingDataHistory
    {
        public string Symbol { get; set; }
        public string Price { get; set; }
        public string OpenPrice { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string PercentChange { get; set; }
        public string AvgVolume { get; set; }
        public System.DateTime Date { get; set; }
        public int ScrapeId { get; set; }
    
        public virtual WorldTradingData WorldTradingData { get; set; }
    }
}
