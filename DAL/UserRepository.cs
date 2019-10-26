using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository
    {
        public DbUser Get(String username)
        {
            using (var db = new VyDbContext())
            { 
                return db.DbUsers.FirstOrDefault(b => b.Username == username);
            }
        }

        public DbUser Create(DbUser dbUser)
        {
            using (var db = new VyDbContext())
            {
                dbUser = db.DbUsers.Add(dbUser);
                db.SaveChanges();
                return dbUser;
            }
        }

        public List<DbUser> GetAll()
        {
            using (var db = new VyDbContext())
            {
                return db.DbUsers.ToList();
            }
        }

        public int Count()
        {
            using (var db = new VyDbContext())
            {
                return db.DbUsers.Count();
            }
        }

    }
}
