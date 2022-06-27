using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;


namespace Project01_ATMT
{
    public class RSA
    {
        private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        private RSAParameters publicKey;
        private RSAParameters privateKey;

        public RSA(AES aes)
        {
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }

        public String getPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));

            xs.Serialize(sw, publicKey);
            return sw.ToString();
        }

        public String Encrypt(string Plaintext)
        {
            rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(publicKey);

            var data = Encoding.Unicode.GetBytes(Plaintext);
            var cyphertext = rsa.Encrypt(data, false);

            return Convert.ToBase64String(cyphertext);
        }

        public String Decrypt(string cypherText){
            var data = Convert.FromBase64String(cypherText);
            rsa.ImportParameters(privateKey);

            var plainText = rsa.Decrypt(data, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
