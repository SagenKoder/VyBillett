using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC_plenum_2.DAL
{

    public class Kunder
    {
         public int ID { get; set; }
         public string Fornavn { get; set; }
         public string Etternavn { get; set; }
         public string Adresse { get; set; }
         public string Postnr { get; set; }

         public virtual Poststeder Poststeder {get;set;} 
    }
    public class Poststeder
    {
        public string Postnr { get; set; }
        public string Poststed { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }

    public class KundeContext : DbContext
    {
        public KundeContext()
            : base("name=Kunder")
        {
            Database.CreateIfNotExists();
        }
        
        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poststeder>()
                        .HasKey(p => p.Postnr);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}