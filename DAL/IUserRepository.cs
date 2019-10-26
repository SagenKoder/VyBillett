using System.Collections.Generic;
using Model;

namespace DAL
{
    public interface IUserRepository
    {
        DbUser Get(string username);
        DbUser Create(DbUser dbUser);
        List<DbUser> GetAll();
        int Count();
    }
}