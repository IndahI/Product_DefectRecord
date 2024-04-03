using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord._Repositories
{
    public class SettingRepository : BaseRepository, ISettingRepository
    {
        public SettingRepository(string connetionString)
        {
            this.connectionString = connetionString;
        }

        public List<string> GetData()
        {
            List<string> dataList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Locations";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataList.Add(reader["LocationName"].ToString());
                    }

                    reader.Close();
                }
            }

            return dataList;
        }
    }
}
