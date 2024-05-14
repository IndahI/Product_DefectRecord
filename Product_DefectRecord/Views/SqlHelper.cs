using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord.Views
{
    public class SqlHelper
    {
        private readonly string _connectionString;

        public SqlHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool IsConnection
        {
            get
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        conn.Open();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Connection Error: " + ex.Message);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("General Connection Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
