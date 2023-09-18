using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalCenter.Model
{
    public class LoginValidation
    {
        public bool UsernameValidate(string username)
        {
            int count = 0;
            bool status = false;
            try
            {
                Connection connection = new Connection();
                using (SqlConnection conn = connection.DBConnect())
                {
                    string countQuery = "SELECT COUNT(username) FROM users WHERE username = @Username";

                    using (SqlCommand cmd = new SqlCommand(countQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle the SQL exception, you can log it or show an error message
                Console.WriteLine("SQL Exception: " + ex.Message);
                // You may throw the exception again if needed
            }

            if(count == 1)
            {
                status = true;
            }
            return status;
        }

        public string PasswordValidate(string username)
        {
            string password = "";
            try
            {
                Connection connection = new Connection();
                using (SqlConnection conn = connection.DBConnect())
                {
                    string quary = "SELECT password FROM users WHERE username = @Username";
                    using (SqlCommand cmd = new SqlCommand(quary,conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        password = cmd.ExecuteScalar().ToString();                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            return password;
        }

    }
}
