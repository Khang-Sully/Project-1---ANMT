using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project01_ATMT
{
    public class AES
    {
        private static byte[] iv;
        private static byte[] key;
        public AES(byte[] passphare)
        {
            iv = Encoding.UTF8.GetBytes("!QAZ2WSX#EDC4RFV");
            key = passphare;
        }

        private static AesCryptoServiceProvider CreateProvider()
        {
            AesCryptoServiceProvider cp = new AesCryptoServiceProvider();
            cp.KeySize = 256;
            cp.BlockSize = 128;
            cp.Key = key;
            cp.Padding = PaddingMode.PKCS7;
            cp.Mode = CipherMode.CBC;
            cp.IV = iv;
            return cp;
        }
        public byte[] Encrypt(byte[] data)
        {
            byte[] enc;
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            using (AesCryptoServiceProvider csp = CreateProvider())
            {
                ICryptoTransform encrypter = csp.CreateEncryptor();
                enc = encrypter.TransformFinalBlock(data, 0, data.Length);
                csp.Clear();
            }
            return enc;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] dec;
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            using (AesCryptoServiceProvider csp = CreateProvider())
            {
                try
                {
                    ICryptoTransform decrypter = csp.CreateDecryptor();
                    dec = decrypter.TransformFinalBlock(data, 0, data.Length);
                }
                catch
                {
                    dec = null;
                }
                csp.Clear();
            }
            return dec;
        }
    }
}
