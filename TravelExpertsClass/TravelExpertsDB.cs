using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string con = @"Data Source=localhost;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(con);
        }
    }
}
