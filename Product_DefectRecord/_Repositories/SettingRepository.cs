using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord._Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private string DBConnectionQC;
        private int locationId;
        public SettingRepository()
        {
            DBConnectionQC = ConfigurationManager.ConnectionStrings["DBConnectionQC"].ConnectionString;
        }

        public List<string> GetData()
        {
            List<string> dataList = new List<string>();

            using (SqlConnection connection = new SqlConnection(DBConnectionQC))
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
    
        public int GetID(string locationName)
        {

            using (SqlConnection connection = new SqlConnection(DBConnectionQC))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id FROM Locations WHERE LocationName = @LocationName";
                    command.Parameters.AddWithValue("@LocationName", locationName);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        locationId = Convert.ToInt32(reader["Id"]);
                    }

                    reader.Close();
                }
            }
            return locationId;
        }
    }
}
