using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Products productCN = new CN_Products();
        private string IdProduct = null;
        private bool Edit = false;

        #region constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion constructor

        private void Form1_Load(object sender, EventArgs e)
        { 
            showProducts();
        }

        private void showProducts()
        {
            CN_Products products = new CN_Products();
            dataGridView1.DataSource = products.showProducts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Edit==false)
            {
                try
                {
                    productCN.insertProduct(txtName.Text, txtDescription.Text, txtBrand.Text, txtPrice.Text, txtStock.Text);
                    showProducts();
                    clearForm();
                    MessageBox.Show("Product added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if(Edit==true)
            {
                try
                {
                    productCN.editProduct(txtName.Text, txtDescription.Text, txtBrand.Text, txtPrice.Text, txtStock.Text, IdProduct);
                    showProducts();
                    clearForm();
                    MessageBox.Show("Product updated successfully");
                    Edit = false;
                    btnSave.Text = "Save";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Edit = true;
                btnSave.Text = "Update";
                txtName.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescription.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtBrand.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrice.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                IdProduct = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila porfavor");
            }
        }

       
        private void clearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtBrand.Clear();
            txtPrice.Clear();
            txtStock.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                productCN.deleteProduct(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                showProducts();
            }
            else
            {
                MessageBox.Show("Seleccione una fila porfavor");
            }
        }
    }
}
