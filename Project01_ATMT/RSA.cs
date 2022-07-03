using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace Project01_ATMT
{
    public class RSA
    {

        private static RSAParameters publicKey;
        private static RSAParameters privateKey;

        public void SerializeKeys(string PublicKeyFileName , string PrivateKeyFileName )
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    //Public Key
                    string publickeystring;
                    StreamReader sr = new System.IO.StreamReader(PublicKeyFileName);
                    publickeystring = sr.ReadToEnd();
                    sr.Close();
                    var st = new System.IO.StringReader(publickeystring);
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    publicKey = (RSAParameters)xs.Deserialize(st);
                    //Private Key
                    string privatekeystring;
                    StreamReader sr2 = new System.IO.StreamReader(PrivateKeyFileName);
                    privatekeystring = sr2.ReadToEnd();
                    sr2.Close();
                    var st2 = new System.IO.StringReader(privatekeystring);
                    var xs2 = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    privateKey = (RSAParameters)xs2.Deserialize(st2);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        public void generateKeys(string PublicKeyFileName, string PrivateKeyFileName)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportParameters(false);
                string pubKeyString;
                {
                    //To string
                    var sw = new System.IO.StringWriter();
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    xs.Serialize(sw, publicKey);
                    pubKeyString = sw.ToString();
                    StreamWriter sr2 = new System.IO.StreamWriter(PublicKeyFileName);
                    sr2.Write(pubKeyString);
                    sr2.Close();
                }
                privateKey = rsa.ExportParameters(true);
                string privKeyString;
                {
                    //To string
                    var sw2 = new System.IO.StringWriter();
                    var xs2 = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    xs2.Serialize(sw2, privateKey);
                    privKeyString = sw2.ToString();
                    StreamWriter sr = new System.IO.StreamWriter(PrivateKeyFileName);
                    sr.Write(privKeyString);
                    sr.Close();
                }
            }
        }
        public string Encrypt(string InputText, string PublicKeyFileName)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Public Key
                string publickeystring;
                StreamReader sr = new System.IO.StreamReader(PublicKeyFileName);
                publickeystring = sr.ReadToEnd();
                sr.Close();
                var st = new System.IO.StringReader(publickeystring);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                publicKey = (RSAParameters)xs.Deserialize(st);
                
                //encrypt
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(publicKey);
                var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(InputText);
                var bytesCypherText = rsa.Encrypt(bytesPlainTextData, false);
                //Fix string(bytes -> string)
                var cypherText = Convert.ToBase64String(bytesCypherText);
                /*StreamWriter sw = new System.IO.StreamWriter("encrypted.txt");
                sw.WriteLine(cypherText);
                sw.Close();
                 */
                return cypherText;
            }
        }
        public string Decrypt(string InputText, string PrivateKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Private Key
                string privatekeystring = PrivateKey;
                var st2 = new System.IO.StringReader(privatekeystring);
                var xs2 = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                privateKey = (RSAParameters)xs2.Deserialize(st2);

                /*string encrypted_string;
                StreamReader sr = new System.IO.StreamReader("encrypted.txt");
                encrypted_string = sr.ReadLine();
                sr.Close();
                 */
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);
                var bytesCypherText = Convert.FromBase64String(InputText);
                var bytesPlainTextData = rsa.Decrypt(bytesCypherText, false);
                string decrypted_text = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
                return decrypted_text;
            }
        }

    }
}
