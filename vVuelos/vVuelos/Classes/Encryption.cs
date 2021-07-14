using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vVuelos.Classes
{
    public class Encryption
    {
        public static string EncryptData(string data) {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static string DecryptData(string data)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(data);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}