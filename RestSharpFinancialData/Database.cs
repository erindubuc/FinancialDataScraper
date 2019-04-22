using System;
using System.Data.SqlClient;

namespace RestSharpFinancialData
{
    public class Database
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
            return @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=StockInfo;"
                + "Integrated Security=SSPI;";
        }

        public static void AddCurrentStockInfoIntoDatabase(CompanyInfoResponse stock)
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
                        "INSERT INTO IEXtrading VALUES(@CompanyName, @Symbol, @ChangePercent, @AvgTotalVolume, " +
                        "@LatestPrice, @Open, @High, @Low, @Year52High, @Year52Low, @Date)", connection))
                    {
                        command.Parameters.Add(new SqlParameter("CompanyName", stock.CompanyName));
                        command.Parameters.Add(new SqlParameter("Symbol", stock.Symbol));
                        command.Parameters.Add(new SqlParameter("ChangePercent", stock.ChangePercent));
                        command.Parameters.Add(new SqlParameter("AvgTotalVolume", stock.AvgTotalVolume));
                        command.Parameters.Add(new SqlParameter("LatestPrice", stock.LatestPrice));
                        command.Parameters.Add(new SqlParameter("Open", stock.Open));
                        command.Parameters.Add(new SqlParameter("High", stock.High));
                        command.Parameters.Add(new SqlParameter("Low", stock.Low));
                        command.Parameters.Add(new SqlParameter("Year52High", stock.Week52High));
                        command.Parameters.Add(new SqlParameter("Year52Low", stock.Week52Low));
                        command.Parameters.Add(new SqlParameter("Date", DateTime.Now));
                        command.ExecuteNonQuery();
                        Console.WriteLine($"{stock.Symbol} stock successfully added to IEXtrading table");
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
