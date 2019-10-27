using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BLL;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly UserRepository userRepository;
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        public UserBLL()
        {
            userRepository = new UserRepository();
        }

        public List<DbUser> GetAll()
        {
            return userRepository.GetAll();
        }

        public int Count()
        {
            return userRepository.Count();
        }

        public DbUser AuthenticateAndGetUserIfOk(string username, string password)
        {
            DbUser dbUser = userRepository.Get(username);
            if (dbUser != null)
            {
                if (dbUser.Password.SequenceEqual(CreateHash(password, dbUser.Salt)))
                {
                    return dbUser;
                } 
                else
                {
                    logerror.Warn("User {0} tried to login using a wrong password!", username);
                }
            }
            logerror.Warn("No user named {0} found in the database", username);
            return null;
        }

        public DbUser CreateNewUser(string username, string password)
        {
            try
            {
                var createdUser = new DbUser();
                var salt = CreateSalt();
                var hash = CreateHash(password, salt);
                createdUser.Username = username;
                createdUser.Password = hash;
                createdUser.Salt = salt;


                logdb.Info("Created new User: {0}", createdUser.ToString());
                return userRepository.Create(createdUser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static byte[] CreateHash(string password, byte[] salt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            var b = pbkdf2.GetBytes(keyLength);
            pbkdf2.Dispose();
            return b;
        }

        private static byte[] CreateSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            csprng.Dispose();
            return salt;
        }
    }
}
