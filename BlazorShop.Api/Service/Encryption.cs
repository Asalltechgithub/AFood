
using System.Web.Helpers;

namespace BlazorShop.Api.Service
{
    public class Encryption
    {
        public string createEncryptPassword(string unhashedPassword)
        {
            string hashedPassword = Crypto.HashPassword(unhashedPassword);
            return hashedPassword;
        }

        public bool checkEncryptPassword(string savedHashedPassword, string unhashedPassword)
        {
            if (Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
