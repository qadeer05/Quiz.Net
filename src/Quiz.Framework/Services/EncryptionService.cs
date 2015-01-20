using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Quiz.Domain;
using Quiz.Framework.Interfaces;
using Quiz.Framework.Security;

namespace Quiz.Framework.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly SecuritySettings _securitySettings;

        public EncryptionService()
        {
            _securitySettings = new SecuritySettings { EncryptionKey = "0C158E5C-210A-46C2-9940-FC744E9E1C68" };
        }

        public EncryptionService(SecuritySettings securitySettings)
        {
            _securitySettings = securitySettings;
        }

        //public virtual string CreatePasswordHash(string password, User user)
        //{
        //    if (user == null)
        //    {
        //        return string.Empty;
        //    }
        //    string saltKey = user.Email;
        //    if (user.Email.Length < 6)
        //    {
        //        saltKey = user.Email.PadRight(7, 'x');
        //    }
            
        //    string saltAndPassword = String.Concat(password, saltKey.Substring(0,5));
        //    string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPassword, "SHA1");
        //    return hashedPassword;
        //}

    }
}
