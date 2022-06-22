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
        private static byte[] iv = Encoding.UTF8.GetBytes("!QAZ2WSX#EDC4RFV");
        private static byte[] key = new byte[32] {
            // 19127443: Ho Dang Khoa
            0x31, 0x39, 0x31, 0x32, 0x37, 0x34, 0x34, 0x33,
            // 19127436: Tang Tuong Khang
            0x31, 0x39, 0x31, 0x32, 0x37, 0x34, 0x33, 0x36,
            // 19127325: Nguyen Huu Hoang An
            0x31, 0x39, 0x31, 0x32, 0x37, 0x33, 0x32, 0x35,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };
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
        public static byte[] Encrypt(byte[] data)
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

        public static byte[] Decrypt(byte[] data)
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
