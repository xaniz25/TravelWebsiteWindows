using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsClass;

namespace TravelExperts
{
    /*Code for the Suppliers window. By Shanice Talan
     Displays list of suppliers and shows associated products for each supplier.
     New suppliers can be added, modified, and deleted, and new products can be added to the supplier
    */
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        private void suppliersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.suppliersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.travelExpertsDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please complete the form!");
            }

        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products_Suppliers' table. You can move, or remove it, as needed.
            this.products_SuppliersTableAdapter.Fill(this.travelExpertsDataSet.Products_Suppliers);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.travelExpertsDataSet.Suppliers);

            GetProducts();

        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void supplierIdTextBox_TextChanged(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void GetProducts()
        {
            /*retrieves Products that are associated with selected Supplier from the database
            and show it in a detail grid view */
            if (Int32.TryParse(supplierIdTextBox.Text, out int SupplierId))
            {
                dgvProducts.DataSource = Products_SuppliersDB.GetProductsBySupplier(SupplierId);
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        /*Adds a new Product to the Supplier by creating new Supplier and Product objects
         * and getting the IDs from the appropriate control to pass as args*/
        {
            TravelExpertsClass.Products prod = new TravelExpertsClass.Products(); //there's 2 Products.cs
            Supplier sup = new Supplier();

            prod.ProductsID = Convert.ToInt32(prodNameComboBox.SelectedValue);
            sup.SupplierID = Convert.ToInt32(supplierIdTextBox.Text);

            Products_SuppliersDB.AddProductSupplier(sup, prod);
        }
    }
}
