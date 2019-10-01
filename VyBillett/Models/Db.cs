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
        }

        DbSet<Category> Categories { get; set; }
    }
}
