using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    public static class SecurityUtilities
    {
         public static string MD5Digest(string txt)
        {
            string digest = "";
            MD5 md5 = MD5CryptoServiceProvider.Create();
            Byte[] bytes = Encoding.Default.GetBytes(txt);
            Byte[] hashByte = md5.ComputeHash(bytes);
            digest = BitConverter.ToString(hashByte).Replace("-", String.Empty).ToLower();
            return digest;
        }

        public static string Sha1Digest(string txt)
        {
            string digest = "";
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] bytes = Encoding.Default.GetBytes(txt);
            Byte[] hashByte = sha1.ComputeHash(bytes);
            digest = BitConverter.ToString(hashByte).Replace("-", String.Empty).ToLower();
            return digest;
        }
    }
}
