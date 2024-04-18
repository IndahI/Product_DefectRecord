using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Product_DefectRecord._Repositories
{
    public class DefectRepository : BaseRepository, IDefectRepository
    {
        //Constructor
        public DefectRepository(string connetionString)
        {
            this.connectionString = connetionString;
        }
        public void Add(dynamic model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                //command.CommandText = "SELECT Nik FROM Users WHERE Name = @InspectorName";
                //command.Parameters.Add("@InspectorName", SqlDbType.VarChar).Value = model.InspectorName;
                //int inspectorId = (int)command.ExecuteScalar();

                command.CommandText = "INSERT INTO Defect_Results (DateTime, SerialNumber, ModelCode, DefectId, InspectorId, LocationId) values (@DateTime, @SerialNumber, @ModelCode, @DefectId, @InspectorId, @LocationId)";
                command.Parameters.Add("@DateTime", SqlDbType.SmallDateTime).Value = DateTime.Now;
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = model.SerialNumber;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;
                command.Parameters.Add("@DefectId", SqlDbType.Int).Value = model.DefectId;
                command.Parameters.Add("@InspectorId", SqlDbType.VarChar).Value = model.InspectorId;
                command.Parameters.Add("@LocationId", SqlDbType.Int).Value = model.Location;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE from Defect_Names WHERE Id = @Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(DefectModel defectmodel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE Defect_Names set Id=@Id, PartId=@PartId, DefectName=@DefectName WHERE Id=@Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = defectmodel.Id1;
                command.Parameters.Add("@PartId", SqlDbType.VarChar).Value = defectmodel.PartId1;
                command.Parameters.Add("@DefectName", SqlDbType.VarChar).Value = defectmodel.DefectName1;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DefectModel> GetAll()
        {
            var defectList = new List<DefectModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Defect_Names.Id, Parts.PartName, Defect_Names.DefectName " +
                                        "FROM Defect_Names " +
                                        "INNER JOIN Parts ON Defect_Names.PartId = Parts.Id " +
                                        "ORDER BY Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var defectModel = new DefectModel();
                        defectModel.Id1 = int.Parse(reader[0].ToString());
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

        public IEnumerable<DefectModel> GetFilter(int id)
        {
            var defectList = new List<DefectModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Defect_Names.Id, Parts.PartName, Defect_Names.DefectName " +
                              "FROM Defect_Names " +
                              "INNER JOIN Parts ON Defect_Names.PartId = Parts.Id " +
                              "WHERE Defect_Names.PartId = @selectedId";

                command.Parameters.AddWithValue("@selectedId", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var defectModel = new DefectModel();
                        defectModel.Id1 = int.Parse(reader[0].ToString());
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
