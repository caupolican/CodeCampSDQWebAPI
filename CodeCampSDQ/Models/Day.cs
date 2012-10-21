using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCampSDQ.Models
{
    public class Day
    {
        public Day()
        {
            Sessions = new List<Session>();
        }

        public int Id { get; set; }

        DateTime Date { get; set; }

        public string DateTimeDisplay { get { return Date.ToString("ddd MMM dd H:mm"); } }

        ICollection<Session> Sessions { get; set; }

    }
}