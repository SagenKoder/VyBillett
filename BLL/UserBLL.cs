using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL
{
    public class UserBLL
    {
        UserRepository db = new UserRepository();

        public DbUser AuthenticateAndGetUserIfOk(String username, String password)
        {
            DbUser dbUser = db.Get(username);
            if (dbUser != null)
            {
                if (dbUser.Password.SequenceEqual(createHash(password, dbUser.Salt)))
                {
                    return dbUser;
                }
            }
            return null;
        }

        public DbUser CreateNewUser(String username, String password)
        {
            try
            {
                var createdUser = new DbUser();
                byte[] salt = createSalt();
                byte[] hash = createHash(password, salt);
                createdUser.Username = username;
                createdUser.Password = hash;
                createdUser.Salt = salt;
                
                return db.Create(createdUser);
            }
            catch (Exception feil)
            {
                return null;
            }
        }

        private static byte[] createHash(string password, byte[] salt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }

        private static byte[] createSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }
    }
}
