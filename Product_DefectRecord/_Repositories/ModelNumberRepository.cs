using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord._Repositories
{
    public class ModelNumberRepository : BaseRepository, IModelNumberRepository
    {
        public ModelNumberRepository(string connetionString)
        {
            this.connectionString = connetionString;
        }

        public ModelCode GetModelNumber(string value)
        {
            string modelCodeValue = value;
            ModelCode modelCode = null;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Global_Model_Code WHERE modelCode = @ModelCode";
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = modelCodeValue;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        modelCode = new ModelCode();
                        // Assuming ModelCode has appropriate constructor or initialization method
                        // Set properties of ModelCode from reader's columns
                        // Example: modelCode.ModelCode1 = (int)reader["modelCode"];
                    }
                }
            }

            return modelCode;
        }
    }
}
