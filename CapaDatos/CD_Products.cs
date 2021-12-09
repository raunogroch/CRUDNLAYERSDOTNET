using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Products
    {
        private CD_Connection connection = new CD_Connection();

        SqlDataReader read;

        DataTable table = new DataTable();

        SqlCommand command = new SqlCommand();

        public DataTable show()
        {
            command.Connection = connection.OpenConnection();
            command.CommandText = "MostrarProductos";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            connection.CloseConnection();
            return table;
        }

        public void Insert(string nombre, string desc, string marca, double precio, int stock)
        {
            command.Connection = connection.OpenConnection();
            command.CommandText = "InsertarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@desc", desc);
            command.Parameters.AddWithValue("@marca", marca);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", stock);
            command.ExecuteNonQuery();
            connection.CloseConnection();
            command.Parameters.Clear();
        }

        public void Edit(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            command.Connection = connection.OpenConnection();
            command.CommandText = "EditarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descrip", desc);
            command.Parameters.AddWithValue("@marca", marca);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", stock);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.CloseConnection();
            command.Parameters.Clear();
        }
        public void Delete(int id)
        {
            command.Connection = connection.OpenConnection();
            command.CommandText = "EliminarProducto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idpro", id);
            command.ExecuteNonQuery();
            connection.CloseConnection();
            command.Parameters.Clear();
        }
    }
}
