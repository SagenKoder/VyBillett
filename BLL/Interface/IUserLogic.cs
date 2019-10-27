using System.Collections.Generic;
using Model;

namespace BLL
{
    public interface IUserLogic
    {
        List<DbUser> GetAll();
        int Count();
        DbUser AuthenticateAndGetUserIfOk(string username, string password);
        DbUser CreateNewUser(string username, string password);
    }
}