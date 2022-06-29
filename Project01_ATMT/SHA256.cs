using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project01_ATMT
{
    class SHA256
    {
        private static SHA256CryptoServiceProvider CreateProvider() {
            SHA256CryptoServiceProvider cp = new SHA256CryptoServiceProvider();
            return cp;
        }
        public static byte[] Hash(byte[] data) {
            using (SHA256CryptoServiceProvider csp = CreateProvider()) {
                byte[] hash = csp.ComputeHash(data);
                csp.Clear();
                return hash;
            }
        }
    }
}
