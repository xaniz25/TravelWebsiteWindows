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
using System.Globalization;

namespace TravelExperts
{
    public partial class Main : Form
    /*Code for the Main window by Kai Feng.
    Shows list of all packages and shows products and its suppliers associated to the package.
    Also has tabs to show list of products and suppliers and buttons to show more detail of
    products and suppliers that shows in a new window.
    In the Products and Suppliers tabs, users can add new a new product/supplier,
    by adding it directly to the blank row then clicking the save button.
    Modifying and Deleting can only be done on the separate "Details" forms.
    */
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void packagesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.packagesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.travelExpertsDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please complete the form.");
            }



        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.travelExpertsDataSet.Suppliers);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            // TODO: This line of code loads data into the 'travelExpertsDataSet.Packages' table. You can move, or remove it, as needed.
            this.packagesTableAdapter.Fill(this.travelExpertsDataSet.Packages);

            GetDetails();

            dgvPackage.Columns[1].Width = 200; //inserted by Shanice Talan to adjust the column width

        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            new Products().Show();
        }

        private void btnAddSup_Click(object sender, EventArgs e)
        {
            new Suppliers().Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelPack_Click(object sender, EventArgs e)
        {

        }

        private void packageIdTextBox_TextChanged(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Products prod = new Products();
            prod.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Suppliers supp = new Suppliers();
            supp.Show();
        }

        private void suppliersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        { //clears all text boxes
            packageIdTextBox.Text = "";
            pkgNameTextBox.Text = "";
            pkgStartDateDateTimePicker.Text = "";
            pkgEndDateDateTimePicker.Text = "";
            pkgDescTextBox.Text = "";
            pkgBasePriceTextBox.Text = "";
            pkgAgencyCommissionTextBox.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void GetDetails()
        {
            if (Int32.TryParse(packageIdTextBox.Text, out int pkgId))
            {
                dgvPackage.DataSource = PackagesDB.DisplayProductsSuppliers(pkgId);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        { /*Add Button code added by Shanice Talan. Validation by Kai Feng.
            Create a new Package object then get data from textboxes to be passed as args. */

            Packages pkg = new Packages();

            try
            {
                if (Validator.IsPresent(pkgNameTextBox) && Validator.IsPresent(pkgDescTextBox))
                {
                    if (pkgEndDateDateTimePicker.Value.Date.CompareTo(pkgStartDateDateTimePicker.Value.Date) <= 0)
                    {
                        MessageBox.Show("Start Date must be less than End Date", "Date Selection Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        pkg.PackageID = Convert.ToInt32(packageIdTextBox.Text);
                        pkg.PkgName = pkgNameTextBox.Text;
                        pkg.PkgStartDate = pkgStartDateDateTimePicker.Value;
                        pkg.PkgEndDate = pkgEndDateDateTimePicker.Value;
                        pkg.PkgDesc = pkgDescTextBox.Text;
                        Decimal.TryParse(pkgBasePriceTextBox.Text, out decimal baseprice);
                        Decimal.TryParse(pkgAgencyCommissionTextBox.Text, out decimal commision);
                        if (baseprice < commision)
                        {
                            MessageBox.Show("Commission can not be larger than Base Price!");
                        }
                        else
                        {
                            pkg.PkgBasePrice = baseprice;
                            pkg.PkgAgencyCommission = commision;
                        }
                        PackagesDB.PackageAdd(pkg);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Package Name and Description.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
