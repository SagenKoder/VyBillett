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
            Database.Delete();
            Database.CreateIfNotExists();
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Departure> Departures { get; set; }
        DbSet<Line> Lines { get; set; }
        public DbSet<Station> Stations { get; set; }
        DbSet<Ticket> Tickets { get; set; }

        DbSet<LineStation> LineStations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineStation>().HasKey(p => new { p.LineId, p.StationId });
            modelBuilder.Entity<Line>().HasMany(p => p.LineStations).WithRequired().HasForeignKey(p => p.LineId);
            modelBuilder.Entity<Station>().HasMany(p => p.LineStations).WithRequired().HasForeignKey(p => p.StationId);

            //base.OnModelCreating(modelBuilder);
        }

    }
}
