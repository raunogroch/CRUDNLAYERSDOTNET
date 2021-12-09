using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Connection
    {
        private SqlConnection connection = new SqlConnection(Connection.ConnectionData);
        public SqlConnection OpenConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public SqlConnection CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return connection;
        }
    }
}
