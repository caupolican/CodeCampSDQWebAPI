using System;

namespace CodeCampSDQ.Models
{
	[System.Diagnostics.DebuggerDisplay("MapLocation {Title} {Location}")]
	public class MapLocation
	{
        public int Id { get; set; }

      	public string Title { get; set; }

		public string Subtitle { get; set; }

		public Point Location { get; set; }
	}

}

