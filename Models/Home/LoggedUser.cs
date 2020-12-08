using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysBG.Models.Home
{
    public class LoggedUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
