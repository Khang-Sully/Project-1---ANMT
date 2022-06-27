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
            String query = "exec SP_SEL_All_ACCOUNTS";
            DataTable dt = dp.ExecuteQuery(query);
            foreach (DataRow dtr in dt.Rows)
            {
                DTO_Account acc = new DTO_Account(dtr);
                result.Add(acc);
            }

            return result;
        }
        public string AddAccount(DTO_Account acc)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[6] { acc.Email, acc.Password, acc.Phone, acc.Fullname, acc.dob, acc.Address};
            DataTable dt = dp.ExecuteQuery("exec SP_SIGN_UP @Email , @Password , @Phone , @Fullname , @Dob , @Address", data);
            string isPassed = dt.Rows[0][0].ToString();

            return isPassed;
        }
        public void EditAccount(DTO_Account acc)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[6] { acc.Email, acc.Password, acc.Phone, acc.Fullname,acc.dob, acc.Address};
            dp.ExecuteQuery("exec SP_UPDATE_ACCOUNT @Email , @Password , @Phone , @Fullname , @Dob , @Address", data);
        }
    }
}
