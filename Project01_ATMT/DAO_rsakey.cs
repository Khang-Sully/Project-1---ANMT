using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project01_ATMT
{
    public class DAO_rsakey
    {
        private static DAO_rsakey Instance = null;
        private DAO_rsakey()
        {
        }
        public static DAO_rsakey get_Instance()
        {
            if (Instance == null)
            {
                Instance = new DAO_rsakey();
            }
            return Instance;
        }
        public void AddRSAKey(DTO_rsakey rsakey)
        {
            DataProvider dp = new DataProvider();
            object[] data = new object[4] { rsakey.Email, rsakey.Password, rsakey.Kpublic, rsakey.Kprivate };
            dp.ExecuteQuery("exec SP_SIGN_UP @Email , @Password , @Kpublic , @Kprivate", data);
        }
    }

}
