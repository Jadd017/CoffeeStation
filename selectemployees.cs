using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStation
{
    internal class selectemployees
    {
        public static DataTable selectallemployees()
        {
            string sql = "SELECT empFirst AS 'First Name', empLast AS 'Last Name', empUserName AS 'username',empPass AS 'Password',empAdr AS 'Address', Email,empPhone AS 'Phone Number',dateOfBirth AS 'Date of Birth' FROM employee WHERE status = 1";
            DataTable dt = mysqlDB.getData(sql);
            return dt;
        }
    }
}
