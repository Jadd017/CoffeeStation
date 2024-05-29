using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoffeeStation
{
    internal class updateemployee
    {
        public static void updateEmployee(string firstName, string lastName, string username, string pass, string address, string phone, string dob, string email, string mainusername)
        {
            string sql = "UPDATE employee SET empFirst = '" + firstName + "', empLast = '" + lastName + "', empUserName = '" + username + "', empPass = '" + pass + "', empAdr = '" + address + "', empPhone = '" + phone + "' , managerID = '" + email + "', dateOfBirth = '" + dob + "' WHERE empUserName = '" + mainusername + "'";
            try
            {
                mysqlDB.executeQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool IsUsernameUnique(string username)
        {
            string sql = "SELECT COUNT(*) FROM employee WHERE empUserName = '" + username + "'";
            try
            {
                DataTable result = mysqlDB.getData(sql);
                int count = Convert.ToInt32(result.Rows[0][0]);
                return count == 0; // If count is 0, username is unique
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool IsPasswordValid(string password)
        {
            // Password must contain at least one uppercase letter, one lowercase letter, one digit, and be at least 6 characters long
            return Regex.IsMatch(password, @"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{6,}$");
        }


    }
}

