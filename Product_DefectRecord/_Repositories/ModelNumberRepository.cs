using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_DefectRecord._Repositories
{
    public class ModelNumberRepository : IModelNumberRepository
    {
        public string DBConnection;
        public ModelNumberRepository()
        {
            DBConnection = ConfigurationManager.ConnectionStrings["DBCommon"].ConnectionString;
        }

        public ModelCode GetModelNumber(ModelCode model)
        {
            ModelCode modelCode = null;

            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM GlobalModelCodes WHERE modelCodeId = @modelCode";
                command.Parameters.Add("@modelCode", SqlDbType.VarChar).Value = model.modelCode1;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        modelCode = new ModelCode();
                        modelCode.ModelNumber = reader["ModelNumber"].ToString();
                        modelCode.modelCode1 = reader["modelCodeId"].ToString();
                    }
                }
            }

            return modelCode;
        }
    }
}
