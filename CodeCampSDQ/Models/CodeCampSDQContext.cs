using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeCampSDQ.Models
{
    public class CodeCampSDQContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CodeCampSDQContext>());

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<ConferenceInfo> ConferenceInfoes { get; set; }

        public DbSet<MapLocation> MapLocations { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<Day> Days { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
    }


    public class CodeCampSDQContextInitializer : DropCreateDatabaseAlways<CodeCampSDQContext>
    {
        protected override void Seed(CodeCampSDQContext context)
        {
            base.Seed(context);

#if DEBUG

            AddSession(context);

            context.SaveChanges();
#endif
        }

        private void AddSession(CodeCampSDQContext context)
        {
            var cao = new Speaker
                {
                    Name = "Caupolican Nunez",
                    TwitterHandle = "cao",
                    HeadshotUrl = "/images/speakers/caupolican.jpg",
                    Bio =
                        @"Nacio en el ensanche espaillat, pero de hay se mudo con sus padres a los guandules, donde mocho cabeza y tiro piedra, se graduo de itesa y ahora da aco en minnesota."
                };

            var session = new Session
                {
                    Title = "Simple, Fast, Elastic NoSQL with Couchbase Server and Mono",
                    Abstract =
                        @"Couchbase Server is a simple, fast, and elastic documented-oriented database. It is simple in its document-oriented approach to data modeling, where domain objects may be naturally mapped to their persistence layer. It is simple to monitor and manage in production, elastically allowing administrators to add and remove nodes to a cluster at any time, without downtime. Couchbase Server is fast thanks to its actively managed cache, compatible with (and built upon) memcached. Indexing, analytics and other advanced ways of managing data in a Couchbase cluster are easily available through the definition of incremental Map/Reduce views.",
                    Location = @"Sampson",
                    Begins = new DateTime(2012, 10, 17, 10, 15, 0),
                    Ends = new DateTime(2012, 10, 17, 11, 15, 0),
                    Speakers = new List<Speaker> {cao}
                };

            context.Sessions.Add(session);
        }
    }
}