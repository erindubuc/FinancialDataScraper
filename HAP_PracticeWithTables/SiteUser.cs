using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAP_PracticeWithTables
{
    public class SiteUser
    {
        private string firstName;
        private string lastName;
        private string username;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }

        public SiteUser() { }
        public SiteUser(string firstName, string lastName, string username)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
        }
    }
}
