using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project01_ATMT
{
    public class DTO_rsakey
    {
        public String Email;
        public byte[] Password;
        public byte[] Kpublic;
        public byte[] Kprivate;
        public DTO_rsakey() { }

        public DTO_rsakey(DataRow datarow)
        {
            Email = (String)datarow["_Email"];
            Password = (byte[])datarow["_Password"];
            Kpublic = (byte[])datarow["_Kpublic"];
            Kprivate = (byte[])datarow["_Kprivate"];
           
        }
    }
}
