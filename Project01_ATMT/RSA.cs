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

            //String contain the RSAParameters of Public/Private key
            var swPub = new StringWriter();
            var swPri = new StringWriter();

            //create two var to save the definition of Pulbic & Private key of RSA
            var xsPub = new XmlSerializer(typeof(RSAParameters));
            var xsPri = new XmlSerializer(typeof(RSAParameters));

            //serialize the Public/Private key to two string
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
            //create an instane of RSA to generate Public & Private key
            rsa = new RSACryptoServiceProvider();

            //Import the RSA Public key info to RSAParameters
            RSAParameters publicKey_RSAParameters = rsa.ExportParameters(false);
            publicKey_RSAParameters.Exponent = publicKey;
            rsa.ImportParameters(publicKey_RSAParameters);
            
            //Change plain text -> bytes -> encrypt text
            var data = Encoding.Unicode.GetBytes(Plaintext);
            var cyphertext = rsa.Encrypt(data, false);

            return Convert.ToBase64String(cyphertext);

        }

        public String Decrypt(string cypherText){
            var data = Convert.FromBase64String(cypherText);

            //Decrypt the private key which encrypted by AES
            byte[] dec = AES.Decrypt(privateKey);

            //Import the RSA Private key info to RSAParameters
            RSAParameters privateKey_RSAParameters = rsa.ExportParameters(true);
            privateKey_RSAParameters.D = dec;
            rsa.ImportParameters(privateKey_RSAParameters);
            
            //Change decrypt -> var -> string -> plain text
            var plainText = rsa.Decrypt(data, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
