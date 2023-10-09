using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDADO.Models
{
    internal class AppConnection
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        public static SqlConnection GetConnection()
        {

            var connection = new SqlConnection(ConnectionString);
            // Dapper를 사용할 경우 자체적으로 Open()함수를 호출하므로 아래가 필요없다.
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to database! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new Exception("Failed to connect to database.", ex);
            }
            return connection;
        }
    }
}
