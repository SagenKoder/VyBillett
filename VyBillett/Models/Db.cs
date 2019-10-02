using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VyBillett.Models
{
    public class Db : DbContext
    {
        public Db() : base("name=VyDb")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DbInit());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<LineStation> LineStations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

    }
}
