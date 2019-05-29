﻿using System;
using System.Data.SqlClient;

namespace HTMLagilityPackScraper
{
    public class Database
    {
        public static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        public static string GetConnectionString()
        {
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
                        "INSERT INTO CNNmoneyStocks VALUES(@CompanyName, @Price, @Change, @PercentChange, @Date)", connection))
                        /*
                        "IF NOT EXISTS(SELECT * FROM WorldTradingData WHERE Symbol = @Symbol) INSERT INTO WorldTradingData VALUES(@Symbol, @Price, @OpenPrice, @HighPrice, @LowPrice," +
                        "@PercentChange, @AvgVolume, @Date)" +
                        "ELSE UPDATE WorldTradingData SET PercentChange = @PercentChange, AvgVolume = @AvgVolume, " +
                           "Price = @Price, OpenPrice = @OpenPrice, HighPrice = @HighPrice, LowPrice = @LowPrice, Date = @Date WHERE Symbol = @Symbol", connection))
                        */
                        {
                        command.Parameters.Add(new SqlParameter("CompanyName", stock.CompanyName));
                        command.Parameters.Add(new SqlParameter("Price", stock.Price));
                        command.Parameters.Add(new SqlParameter("Change", stock.Change));
                        command.Parameters.Add(new SqlParameter("PercentChange", stock.PercentChange));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{stock.CompanyName} stock successfully added");
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
    }

}
/*
using (SqlCommand command = new SqlCommand(
                        
                        "INSERT INTO WorldTradingData VALUES(@Symbol, @Price, @OpenPrice, @HighPrice, @LowPrice, " +
                        "@PercentChange, @AvgVolume, @Date)", connection))
                        
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
    */