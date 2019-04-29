using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockScraper.Services
{
    public class Database : WebDriver
    {
        public static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        public static string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=StockInfo;"
                + "Integrated Security=SSPI;";
        }

        public static void AddCurrentStockInfoIntoDatabase(Stock stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "IF NOT EXISTS(SELECT * FROM CurrentStockInfo WHERE Symbol = @Symbol) INSERT INTO CurrentStockInfo VALUES(@StockId, @Symbol, @PercentChange, @AvgVolume, " +
                        "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow, @Date)" +
                        "ELSE UPDATE CurrentStockInfo SET Stock_Id = @StockId , PercentChange = @PercentChange, AverageVolume = @AvgVolume, " +
                            "LastPrice = @Last, MarketTime = @MarketTime, OpenPrice = @Open, HighPrice = @High, LowPrice = @Low, YearWeekHigh = @YearWeekHigh, " +
                            "YearWeekLow = @YearWeekLow, Date = @Date WHERE Symbol = @Symbol", connection))

                    {
                        command.Parameters.Add(new SqlParameter("StockId", stock.StockId));
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("Last", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("MarketTime", stock.MarketTime));
                        command.Parameters.Add(new SqlParameter("Open", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("High", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("Low", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("YearWeekHigh", stock.YearWeekHigh));
                        command.Parameters.Add(new SqlParameter("YearWeekLow", stock.YearWeekLow));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{stock.Symbol} stock successfully added");
                    }

                    Console.WriteLine("The database has been successfully updated.");

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into database");
                    throw e;
                }
            }
        }

        public static void MoveCurrentStockInfoToHistoryOfStocksTable(Stock stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(
                    "INSERT INTO HistoryOfStockInfo VALUES(@StockId, @Symbol, @PercentChange, @AvgVolume, " +
                        "@Last, @MarketTime, @Open, @High, @Low, @YearWeekHigh, @YearWeekLow, @Date) " +
                        "SELECT * FROM CurrentStockInfo", connection))

                    {
                        command.Parameters.Add(new SqlParameter("StockId", stock.StockId));
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("Last", stock.LastPrice));
                        command.Parameters.Add(new SqlParameter("MarketTime", stock.MarketTime));
                        command.Parameters.Add(new SqlParameter("Open", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("High", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("Low", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("YearWeekHigh", stock.YearWeekHigh));
                        command.Parameters.Add(new SqlParameter("YearWeekLow", stock.YearWeekLow));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();

                        Console.WriteLine($"All stocks successfully moved to History Table");
                    }

                    Console.WriteLine("The history table been successfully updated.");
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into history table");

                    throw e;
                }
            }
        }

        public static void AddCurrentWorldTradingDataInfoIntoDatabase(CallForStockInfo stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //Console.WriteLine("State: {0}", connection.State);
                //Console.WriteLine("ConnectionString: {0}",
                //    connection.ConnectionString);

                try
                {
                    using (SqlCommand command = new SqlCommand(
                        /*
                        "INSERT INTO WorldTradingData VALUES(@Symbol, @Price, @OpenPrice, @HighPrice, @LowPrice, " +
                        "@PercentChange, @AvgVolume, @Date)", connection))
                        */
                        "IF NOT EXISTS(SELECT * FROM WorldTradingData WHERE Symbol = @Symbol) INSERT INTO WorldTradingData VALUES(@Symbol, @Price, @OpenPrice, @HighPrice, @LowPrice," +
                        "@PercentChange, @AvgVolume, @Date)" +
                        "ELSE UPDATE WorldTradingData SET PercentChange = @PercentChange, AvgVolume = @AvgVolume, " +
                            "Price = @Price, OpenPrice = @OpenPrice, HighPrice = @HighPrice, LowPrice = @LowPrice, Date = @Date WHERE Symbol = @Symbol", connection))
                    {
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("Price", stock.Price));
                        command.Parameters.Add(new SqlParameter("OpenPrice", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("HighPrice", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("LowPrice", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{stock.Symbol} stock successfully added to WorldTradingData table");
                    }

                    Console.WriteLine("The database has been successfully updated.");

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into database");

                    throw e;
                }
            }
        }

        public static void MoveWorldTradingDataInfoToHistoryOfStocksTable(CallForStockInfo stock)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(
                    "INSERT INTO WorldTradingDataHistory VALUES(@Symbol, @Price, @OpenPrice, @HighPrice, @LowPrice, " +
                        "@PercentChange, @AvgVolume, @Date) " +
                        "SELECT * FROM WorldTradingData", connection))

                    {
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("Price", stock.Price));
                        command.Parameters.Add(new SqlParameter("OpenPrice", stock.OpenPrice));
                        command.Parameters.Add(new SqlParameter("HighPrice", stock.HighPrice));
                        command.Parameters.Add(new SqlParameter("LowPrice", stock.LowPrice));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("AvgVolume", stock.AvgVolume));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        //command.Parameters.Add(new SqlParameter("ScrapeId", stock.ScrapeId));
                        command.ExecuteNonQuery();

                        Console.WriteLine($"All stocks successfully moved to History Table");
                    }

                    Console.WriteLine("The history table been successfully updated.");
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Values could not be inserted into history table");

                    throw e;
                }
            }
        }
    }
}
