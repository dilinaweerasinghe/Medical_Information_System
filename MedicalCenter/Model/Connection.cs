using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Model
{
    public class Connection
    {

        public SqlConnection DBConnect() {
            String sqlString = "Data Source=DILINA-LAPTOP;Initial Catalog=mcdb;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sqlString);
            conn.Open();
            return conn;
        }
    }
}
