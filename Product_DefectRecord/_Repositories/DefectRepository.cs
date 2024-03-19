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
    public class DefectRepository : BaseRepository, IDefectRepository
    {
        //Constructor
        public DefectRepository(string connetionString)
        {
            this.connectionString = connetionString;
        }
        public void Add(DefectModel defectmodel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(DefectModel defectmodel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DefectModel> GetAll()
        {
            var defectList = new List<DefectModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * from Defect_Names ORDER BY Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var defectModel = new DefectModel();
                        defectModel.Id1 = (int)reader[0];
                        defectModel.PartId1 = reader[1].ToString();
                        defectModel.DefectName1 = reader[2].ToString();
                        defectList.Add(defectModel);
                    }

                }
            }

            return defectList;
        }

        public IEnumerable<DefectModel> GetByValue(string value)
        {
            var defectList = new List<DefectModel>();
            int defectId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string defectName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * from Defect_Names 
                                        WHERE Id = @Id OR DefectName like @DefectName+'%'
                                        ORDER BY Id desc";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = defectId;
                command.Parameters.Add("@DefectName", SqlDbType.VarChar).Value = defectName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var defectModel = new DefectModel();
                        defectModel.Id1 = (int)reader[0];
                        defectModel.PartId1 = reader[1].ToString();
                        defectModel.DefectName1 = reader[2].ToString();
                        defectList.Add(defectModel);
                    }

                }
            }

            return defectList;
        }
    }
}
