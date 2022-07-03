using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project01_ATMT
{
    public class DAO_Account
    {
        private static DAO_Account Instance = null;
        private DAO_Account()
        {
        }
        public static DAO_Account get_Instance()
        {
            if (Instance == null)
            {
                Instance = new DAO_Account();
            }
            return Instance;
        }
        public List<DTO_Account> LoadUserList()
        {
            List<DTO_Account> result = new List<DTO_Account>();
            DataProvider dp = new DataProvider();
            DataTable dt = dp.ExecuteQuery("exec SP_SEL_All_ACCOUNTS");
            foreach (DataRow dtr in dt.Rows)
            {
                DTO_Account acc = new DTO_Account(dtr);
                result.Add(acc);
            }

            return result;
        }
        public DataTable getUserInfo(String loginEmail) {
            DataProvider dp = new DataProvider();
            object[] email = new object[1] { loginEmail };
            DataTable dt = dp.ExecuteQuery("EXEC SP_SEL_ACCOUNT @EMAIL", email);

            return dt;
        }

        public string AddAccount(DTO_Account acc, String PublicKeyFileName, String PrivateKeyFileName)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[8] { acc.Email, acc.Password, acc.Phone, acc.Fullname, acc.dob, acc.Address, PublicKeyFileName , PrivateKeyFileName };
            DataTable dt = dp.ExecuteQuery("exec SP_SIGN_UP @Email , @Password , @Phone , @Fullname , @Dob , @Address , @KPublic , @KPrivate", data);
            string isPassed = dt.Rows[0][0].ToString();

            return isPassed;
        }

        public void EditAccount(DTO_Account acc)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[6] { acc.Email, acc.Password, acc.Phone, acc.Fullname, acc.dob, acc.Address};
            dp.ExecuteQuery("exec SP_UPDATE_ACCOUNT @Email , @Password , @Phone , @Fullname , @Dob , @Address", data);
        }

        public string GetPublickey(String Email) 
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[1] { Email };
            DataTable dt =dp.ExecuteQuery("exec SP_SEL_PUBLICKEY @Email", data);

            string PublicKeyFilePath = dt.Rows[0][0].ToString();
            return PublicKeyFilePath;
        }
        public string GetPrivateKey(String Email)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[1] { Email };
            DataTable dt = dp.ExecuteQuery("exec SP_SEL_PRIVATEKEY @Email", data);

            string PublicKeyFilePath = dt.Rows[0][0].ToString();
            return PublicKeyFilePath;
        }
        public void AddMFile(String FromEmail, String DestEmail, String SessionKey, String Filename)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[4] { FromEmail, DestEmail, SessionKey, Filename };
            dp.ExecuteQuery("exec SP_ADD_MFILE @FromEmail , @DestEmail , @SessionKey , @FilePath", data);

        }

        public String GetSessionKey(string Email, string Filepath)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[2] { Email , Filepath };
            DataTable dt = dp.ExecuteQuery("exec SP_GET_SESSIONKEY @Email , @FilePath", data);

            String sessionKey = dt.Rows[0][0].ToString();
            return sessionKey;
        }
    }
}
