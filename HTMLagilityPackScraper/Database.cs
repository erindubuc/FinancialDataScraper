using System;
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
                       
                    
                    "IF NOT EXISTS(SELECT * FROM CNNmoneyStocks WHERE CompanyName = @CompanyName) INSERT INTO CNNmoneyStocks VALUES(@StockId, @CompanyName, @Price, @Change, " +
                    "@PercentChange, @Date)" +
                    "ELSE UPDATE CNNmoneyStocks SET StockId = @StockId , Price = @Price, Change = @Change, PercentChange = @PercentChange, Date = @Date WHERE CompanyName = @CompanyName", connection))
                    
                    {
                        command.Parameters.Add(new SqlParameter("StockId", stock.StockId));
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
