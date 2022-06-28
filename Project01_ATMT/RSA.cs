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
        private byte[] publicKey;
        private byte[] privateKey;

        public RSA(AES aes)
        {
            RSAParameters tempPublicKey = rsa.ExportParameters(false);
            RSAParameters tempPrivateKey = rsa.ExportParameters(true);
            var swPub = new StringWriter();
            var swPri = new StringWriter();
            var xsPub = new XmlSerializer(typeof(RSAParameters));
            var xsPri = new XmlSerializer(typeof(RSAParameters));

            xsPub.Serialize(swPub, tempPublicKey);
            publicKey = Encoding.ASCII.GetBytes(swPub.ToString());
            xsPri.Serialize(swPri, tempPrivateKey);
            privateKey = AES.Encrypt(Encoding.ASCII.GetBytes(swPri.ToString()));

        }

        public String getPublicKey()
        {
            return publicKey.ToString();
        }

        public String Encrypt(string Plaintext)
        {
            rsa = new RSACryptoServiceProvider();
            RSAParameters publicKey_RSAParameters = rsa.ExportParameters(false);
            publicKey_RSAParameters.Exponent = publicKey;
            rsa.ImportParameters(publicKey_RSAParameters);

            var data = Encoding.Unicode.GetBytes(Plaintext);
            var cyphertext = rsa.Encrypt(data, false);

            return Convert.ToBase64String(cyphertext);

        }

        public String Decrypt(string cypherText){
            var data = Convert.FromBase64String(cypherText);

            byte[] dec = AES.Decrypt(privateKey);
            RSAParameters privateKey_RSAParameters = rsa.ExportParameters(true);
            privateKey_RSAParameters.D = dec;
            rsa.ImportParameters(privateKey_RSAParameters);
            /*
             */
            var plainText = rsa.Decrypt(data, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
