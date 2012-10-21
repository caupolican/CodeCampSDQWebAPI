using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCampSDQ.Models
{
    public class Schedule
    {
        public Schedule()
        {
            Days = new List<Day>();
        }

        public int Id { get; set; }

        public ICollection<Day> Days { get; set; }
    }


}