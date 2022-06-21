using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Project01_ATMT
{
    public class DTO_Account
    {
        public String Email;
        public byte[] Password;
        public String Phone;
        public String Fullname;
        public String dob;
        public String Address;
        public DTO_Account() { }

        public DTO_Account(DataRow datarow) {
            Email = (String)datarow["_Email"];
            Password = (byte[])datarow["_Password"];
            Phone = (String)datarow["_Phone"];
            Fullname = (String)datarow["_Fullname"];
            dob = (String)datarow["_Dob"];
            Address = (String)datarow["_Address"];
        }
    }
}
