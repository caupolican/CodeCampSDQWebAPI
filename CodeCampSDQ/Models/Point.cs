using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCampSDQ.Models
{
    public class Point
    {
        public int Id { get; set; }

        public Point()
        {
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}