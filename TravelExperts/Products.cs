using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsClass;

namespace TravelExperts
{
    /*Code for the Products window. By Victor Lantion
     Displays list of products and shows associated suppliers for each product
     New products can be added, modified, and deleted, and new suppliers can be added to the product
     */
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.Validate();
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.travelExpertsDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please complete the form.");
            }

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.travelExpertsDataSet.Suppliers);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            dgvSuppliers.Columns[0].Width = 220; //inserted by Shanice Talan to adjust width of column
        }

        private void productIdLabel_Click(object sender, EventArgs e)
        {
            GetSupplier();
        }

        private void productIdTextBox_TextChanged(object sender, EventArgs e)
        {
            GetSupplier();
        }

        private void prodNameLabel_Click(object sender, EventArgs e)
        {
            GetSupplier();
        }

        private void prodNameTextBox_TextChanged(object sender, EventArgs e)
        {
            GetSupplier();
        }

        private void GetSupplier()
        {
            if (Int32.TryParse(productIdTextBox.Text, out int ProductId))
            {
                dgvSuppliers.DataSource = Products_SuppliersDB.GetSupplierByProducts(ProductId);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        /*Adds a new Product to the Supplier by creating new Supplier and Product objects
          and getting the IDs from the appropriate control to pass as args.
          Added by Shanice Talan*/
        {
            TravelExpertsClass.Products prod = new TravelExpertsClass.Products(); //there's 2 Products.cs
            Supplier sup = new Supplier();

            prod.ProductsID = Convert.ToInt32(productIdTextBox.Text);
            sup.SupplierID = Convert.ToInt32(supNameComboBox.SelectedValue);

            Products_SuppliersDB.AddProductSupplier(sup, prod);
        }
    }
}
