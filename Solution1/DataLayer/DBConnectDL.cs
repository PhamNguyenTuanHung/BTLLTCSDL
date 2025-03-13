using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBConnectDL
    {
        public static SqlConnection Connect()
        {

            string conn = @"Data Source=BLUE\BLUE;Initial Catalog=QLSV;Integrated Security=True;";
            
            try
            {
                SqlConnection SqlCon = new SqlConnection(conn);
                
                return SqlCon;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();


            using (SqlConnection connect = DBConnectDL.Connect())
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
