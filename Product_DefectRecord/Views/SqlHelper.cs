using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord.Views
{
    public class SqlHelper
    {
        SqlConnection LSBUDBConnection;

        public SqlHelper(string connectionString)
        {
            LSBUDBConnection = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if(LSBUDBConnection.State == System.Data.ConnectionState.Closed)
                    LSBUDBConnection.Open();
                return true;
            }
        }
    }
}
