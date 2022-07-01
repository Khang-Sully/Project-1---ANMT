using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project01_ATMT
{
    public class SHA256
    {
        private static SHA256CryptoServiceProvider CreateProvider() {
            SHA256CryptoServiceProvider cp = new SHA256CryptoServiceProvider();
            return cp;
        }
        public static byte[] Hash(string data, string salt) {
            byte[] bytes = Encoding.UTF8.GetBytes(data + salt);
            using (SHA256CryptoServiceProvider csp = CreateProvider()) {
                byte[] hash = csp.ComputeHash(bytes);
                csp.Clear();
                return hash;
            }
        }
    }
}
