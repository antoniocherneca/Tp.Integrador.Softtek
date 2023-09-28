using System.Security.Cryptography;
using System.Text;

namespace Tp.Integrador.Softtek.Helpers
{
    public static class PasswordEncryptHelper
    {
        public static string EncryptPassword(string password, string email)
        {
            var salt = CreateSalt(email);
            string saltAndPass = String.Concat(password, salt);
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = Array.Empty<byte>();
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPass));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            
            return sb.ToString();
        }

        private static string CreateSalt(string email)
        {
            var salt = email;
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach (int x in saltBytes)
            {
                XORED = XORED ^ x;
            }

            Random rand = new Random(Convert.ToInt32(XORED));
            saltStr = rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();

            return saltStr;
        }
    }
}
