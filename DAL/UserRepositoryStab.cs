using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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

            var dbUser = new DbUser { Username = username, Password = null, Salt = null};
            return dbUser;
        }

        public DbUser Create(DbUser dbUser)
        {
            if (dbUser.Username == "")
            {
                return null;
            }
            else
            {
                return dbUser;
            }
        }

        public List<DbUser> GetAll()
        {
            var userList = new List<DbUser>();
            var salt = CreateSalt();
            var dbUser = new DbUser { Username = "username", Password = CreateHash("password", salt), Salt = salt };

            userList.Add(dbUser);
            userList.Add(dbUser);
            userList.Add(dbUser);
            return userList;
        }

        public int Count()
        {
            return 3;
        }

        private byte[] CreateSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }
        private static byte[] CreateHash(string password, byte[] salt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }
    }
}
