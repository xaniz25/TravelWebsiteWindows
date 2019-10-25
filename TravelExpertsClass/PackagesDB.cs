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
   public static class PackagesDB
   {//Code by Kai Feng

        //get packages from package table
        public static List<Packages> DisplayPackagesInList(string text)
        {
            List<Packages> packageList = new List<Packages>(); //crating empty list
            Packages packageObj = null;                       //referencing package object

            string selectQuery = "SELECT * FROM Packages ORDER BY PackageId";   //SQL query to get all fields from table

            try
            {

                using (SqlConnection con = TravelExpertsDB.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    {
                        con.Open();                             //databse connection opens
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            packageObj = new Packages();         //instantiating the object of the class Package      
                            packageObj.PackageID = (int)dr["PackageId"];
                            packageObj.PkgName = (string)dr["PkgName"];
                            packageObj.PkgStartDate = dr["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dr["PkgStartDate"];
                            packageObj.PkgEndDate = dr["PkgEndDate"] == DBNull.Value ? null : (DateTime?)dr["PkgEndDate"];
                            packageObj.PkgDesc = dr["PkgDesc"] == DBNull.Value ? null : (string)dr["PkgDesc"];
                            packageObj.PkgBasePrice = decimal.Parse(dr["PkgBasePrice"].ToString());
                            packageObj.PkgAgencyCommission = decimal.Parse(dr["PkgAgencyCommission"].ToString());
                            packageList.Add(packageObj);        
                        }
                    }
                    return packageList;                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //adds new package
        public static void PackageAdd(Packages pkgObj)
        {
            string insert = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission) " +
                                    "VALUES (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission) ";

            try
            {

                using (SqlConnection con = TravelExpertsDB.GetConnection()) //doesn't require to close connection as USING method doest it by itself
                {
                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        con.Open();  //databse connection opens
                        //cmd.Parameters.AddWithValue("@PackageId", pkgObj.PackageID);  //id is auto-generated in the database as its primary key?                                
                        cmd.Parameters.AddWithValue("@PkgName", pkgObj.PkgName);
                        cmd.Parameters.AddWithValue("@PkgBasePrice", pkgObj.PkgBasePrice);
                        cmd.Parameters.AddWithValue("@PkgStartDate", pkgObj.PkgStartDate);
                        cmd.Parameters.AddWithValue("@PkgEndDate", pkgObj.PkgEndDate);
                        cmd.Parameters.AddWithValue("@PkgDesc", pkgObj.PkgDesc);
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkgObj.PkgAgencyCommission);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //updates package
        public static bool PackageUpdate(Packages package, Packages newPackage)
        {
            bool result = true;

            string updateStatement = "UPDATE Packages SET  PkgName = @newPkgName, " +
                                      "PkgStartDate = @newPkgStartDate, " +
                                     "PkgEndDate = @newPkgEndDate, " +
                                     "PkgDesc = @newPkgDesc, " +
                                     "PkgBasePrice=@newPkgBasePrice, " +
                                     "PkgAgencyCommission = @newPkgAgencyCommission " +
                                     "WHERE PackageId = @oldPackageId ";


            try
            {
                using (SqlConnection con = TravelExpertsDB.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(updateStatement, con))
                    {
                        con.Open();
                        //cmd.Parameters.AddWithValue("@PackageId", newPackage.PackageId);
                        cmd.Parameters.AddWithValue("@newPkgName", newPackage.PkgName);
                        cmd.Parameters.AddWithValue("@newPkgBasePrice", newPackage.PkgBasePrice);
                        if (newPackage.PkgStartDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@newPkgStartDate", newPackage.PkgStartDate);
                        }
                        else cmd.Parameters.AddWithValue("@newPkgStartDate", DBNull.Value);

                        if (newPackage.PkgEndDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@newPkgEndDate", newPackage.PkgEndDate);
                        }
                        else cmd.Parameters.AddWithValue("@newPkgEndDate", DBNull.Value);

                        if (newPackage.PkgDesc == null)
                        {
                            cmd.Parameters.AddWithValue("@newPkgDesc", "");
                        }
                        else cmd.Parameters.AddWithValue("@newPkgDesc", newPackage.PkgDesc);

                        if (newPackage.PkgAgencyCommission == null)
                        {
                            cmd.Parameters.AddWithValue("@newPkgAgencyCommission", 0);
                        }
                        else
                            cmd.Parameters.AddWithValue("@newPkgAgencyCommission", newPackage.PkgAgencyCommission);

                        cmd.Parameters.AddWithValue("@oldPackageId", package.PackageID);
                        cmd.Parameters.AddWithValue("@oldPkgName", package.PkgName);
                        cmd.Parameters.AddWithValue("@oldPkgBasePrice", package.PkgBasePrice);
                        if (package.PkgStartDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgStartDate", package.PkgStartDate);
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgStartDate", DBNull.Value);

                        if (package.PkgEndDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgEndDate", package.PkgEndDate);
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgEndDate", DBNull.Value);

                        if (package.PkgDesc == null)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgDesc", "");
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgDesc", package.PkgDesc);

                        if (package.PkgAgencyCommission == null)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgAgencyCommission", package.PkgAgencyCommission);
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgAgencyCommission", 0);

                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated == 0) result = false; // did not update (another user updated or deleted)
                    }


                    return result;
                }
            }
            catch (DBConcurrencyException ex)
            {
                throw ex;
            }
        }

        //gets Products and Suppliers associated with the selected Package
        public static DataTable DisplayProductsSuppliers(int PackageId)
        {
            DataTable dt;

            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                string query = "select pr.ProdName as [Products], s.SupName as [Supplier]" +
                                "from Suppliers s " +
                              "inner join Products_Suppliers ps " +
                               "on ps.SupplierId = s.SupplierId " +
                              "inner join Products pr " +
                              "on pr.ProductId = ps.ProductId " +
                               "inner join Packages_Products_Suppliers pps " +
                               "on pps.ProductSupplierId = ps.ProductSupplierId " +
                               "inner join Packages pa " +
                               "on pa.PackageId = pps.PackageId " +
                               "where pa.PackageId = @PackageId ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PackageId", PackageId);
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
    }
}
