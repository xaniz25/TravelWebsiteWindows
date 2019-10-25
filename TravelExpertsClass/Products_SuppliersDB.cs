using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperts;

namespace TravelExpertsClass
{
    public static class Products_SuppliersDB
    //Code by Shanice Talan
    {
        public static DataTable GetProductsBySupplier(int SupplierId)
        { //gets list of products associated with the selected supplier

            DataTable dt;

            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                string query = "select p.ProductId, ProdName as [Product Name] from Suppliers s " +
                               "join Products_Suppliers ps on s.SupplierId = ps.SupplierId " +
                               "join Products p on p.ProductId = ps.ProductId " +
                               "where @SupplierId=s.SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
            }

            return dt;
        }

        public static DataTable GetSupplierByProducts(int ProductId)
        {//gets list of products associated with the selected product

            DataTable dt;

            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                string query = "select s.SupName as [Supplier Name], p.ProdName as [Product Name] " +
                                "from Products_Suppliers ps " +
                               "inner join Suppliers s on ps.SupplierId = s.SupplierId " +
                               "inner join Products p on p.ProductId = ps.ProductId " +
                               "where @ProductId=p.ProductId ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
            }

            return dt;
        }

        public static void AddProductSupplier(Supplier sup, Products prod)
        {/* Adds/connects a supplier to a product, and vice versa,
            by adding their IDs in the Products_Supplier table */

            SqlConnection connect = TravelExpertsDB.GetConnection();
            string insertQuery = "INSERT INTO Products_Suppliers (SupplierId, ProductId) " +
                                  "VALUES (@SupplierId, @ProductId)";

            SqlCommand cmd = new SqlCommand(insertQuery, connect);

            //applies the values to the query
            cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierID);
            cmd.Parameters.AddWithValue("@ProductId", prod.ProductsID);

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            
        }
    }
}
