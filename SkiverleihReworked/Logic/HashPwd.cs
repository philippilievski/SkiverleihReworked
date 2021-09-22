using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SkiverleihReworked.Logic
{
    class HashPwd
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
        public static bool Validation(string username, string passwordHash)
        {
            bool isCorrect = false;
            var skiverleihcontext = new Skiverleihcontext();
            var passwordandusername = skiverleihcontext.Users
                .Where(s => s.Username == username)
                .Where(s => s.PasswordHash == passwordHash)
                .Count();

            if (passwordandusername == 1)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}
