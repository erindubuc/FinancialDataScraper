using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HAP_PracticeWithTables
{
    class Program
    {
        public static void Main(string[] args)
        {
            var html = "https://www.webscraper.io/test-sites/tables";
            var web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var rows = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/table[1]/tbody[1]//tr");

            List<SiteUser> users = new List<SiteUser>();

            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");
                if (cells != null & cells.Count > 0)
                {
                    var firstName = cells[1].InnerText;
                    var lastName = cells[2].InnerText;
                    var username = cells[3].InnerText;

                    Console.WriteLine($"First: {firstName}  | Last: {lastName}  | Username: {username}");
                    Console.WriteLine("-----------------------------------------------");

                    SiteUser newUser = new SiteUser(firstName, lastName, username);
                    users.Add(newUser);
                }
            }

            foreach (var user in users)
                Console.WriteLine($"New User: {user.Username}");
            Console.ReadLine();
        }
    }
}
