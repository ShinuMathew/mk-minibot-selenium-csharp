using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace TestFramework.TestCaseDesigns
{
    public class DBConnect
    {
        public static SqlConnection sc;


        public String OpenDB2(String loc, String DBinstance)
        {
            
            String instance = null;
            if (DBinstance == "CA_QA_DB")
            {
                instance = Variables.Variables.CA_QA_DB;
            }
            else if (DBinstance == "CA_Stg_DB")
            {
                instance = Variables.Variables.CA_Stg_DB;
            }
            
            return instance;

        }
        public void openDBconnection(String loc, String DBinstance)
        {
            
            String instance=null;
            if (DBinstance == "CA_QA_DB")
            {
                instance = Variables.Variables.CA_QA_DB;
            }
            else if (DBinstance == "CA_Stg_DB")
            {
                instance = Variables.Variables.CA_Stg_DB;
            }
           

            sc = new SqlConnection(instance);
            sc.Open();
        }

        public String executequery(String loc, String query)
        {
            SqlCommand scmd = new SqlCommand(query, sc);
            String result = scmd.ExecuteScalar().ToString();
            return result;
        }
                
        public void closeDBconnection()
        {           
            sc.Close();
        }
    

    }
}
