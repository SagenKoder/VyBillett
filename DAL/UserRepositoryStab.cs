using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UserRepositoryStab : IUserRepository
    {
        public DbUser Get(string username)
        {
            if (username == "")
            {
                return null;
            }

            var dbUser = new DbUser {Username = username};
            return dbUser;
        }

        public DbUser Create(DbUser dbUser)
        {
            throw new NotImplementedException();
        }

        public List<DbUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
