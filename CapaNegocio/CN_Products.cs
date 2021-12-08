using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Products
    {
        private CD_Products productsObject = new CD_Products();
        public DataTable showProducts()
        {
            DataTable table = new DataTable();
            table = productsObject.show();  
            return table;
        }

        public void insertProduct(string nombre, string desc, string marca, string precio, string stock)
        {
            productsObject.Insert(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void editProduct(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            productsObject.Edit(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void deleteProduct (string id)
        {
            productsObject.Delete(Convert.ToInt32(id));
        }
    }
}
