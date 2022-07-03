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
    }

}
