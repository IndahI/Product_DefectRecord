using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using ZXing.QrCode.Internal;


namespace Product_DefectRecord._Repositories
{
    public class DefectRepository : IDefectRepository
    {
        //Properties
        private string DBConnection;

        //Constructor
        public DefectRepository()
        {
            DBConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        public IEnumerable<DefectResultModel> GetAllResult()
        {
            var resultList = new List<DefectResultModel>();
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText =
                    "SELECT " +
                    "    DR.Id, " +
                    "    DN.Id AS DefectId, " +
                    "    DR.DateTime, " +
                    "    DR.ModelNumber, " +
                    "    DR.ModelCode, " +
                    "    DR.SerialNumber, " +
                    "    DR.LocationId, " +
                    "    DN.DefectName, " +
                    "    U.Name AS InspectorName " +
                    "FROM " +
                    "    Defect_Results DR " +
                    "INNER JOIN " +
                    "    LSBU_Common.dbo.Users U ON DR.InspectorId = U.NikId " +
                    "INNER JOIN " +
                    "    Defect_Names DN ON DR.DefectId = DN.Id " +
                    "WHERE " +
                    "    CONVERT(date, DR.DateTime) = CONVERT(date, GETDATE())"+
                    "ORDER BY " +
                    "    DR.Id DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var resultModel = new DefectResultModel
                        {
                            Id = reader["Id"].ToString(),
                            Defect = reader["DefectName"].ToString(),
                            Date = reader["DateTime"].ToString(),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            ModelCode = reader["ModelCode"].ToString(),
                            SerialNumber = reader["SerialNumber"].ToString(),
                            LocationId = reader["LocationId"].ToString(),
                            Inspector = reader["InspectorName"].ToString()
                        };
                        resultList.Add(resultModel);
                    }
                }
            }

            return resultList;
        }

        public IEnumerable<DefectResultModel> GetFilterResult(DateTime selectedDate)
        {
            var resultList = new List<DefectResultModel>();
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText =
                    "SELECT " +
                    "    DR.Id, " +
                    "    DN.Id AS DefectId, " +
                    "    DR.DateTime, " +
                    "    DR.ModelNumber, " +
                    "    DR.ModelCode, " +
                    "    DR.SerialNumber, " +
                    "    DR.LocationId, " +
                    "    DN.DefectName, " +
                    "    U.Name AS InspectorName " +
                    "FROM " +
                    "    Defect_Results DR " +
                    "INNER JOIN " +
                    "    LSBU_Common.dbo.Users U ON DR.InspectorId = U.NikId " +
                    "INNER JOIN " +
                    "    Defect_Names DN ON DR.DefectId = DN.Id " +
                    "WHERE " +
                    "    CAST(DR.DateTime AS DATE) = @SelectedDate " +
                    "ORDER BY " +
                    "    DR.Id DESC";

                command.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = selectedDate.Date;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var resultModel = new DefectResultModel
                        {
                            Id = reader["Id"].ToString(),
                            Defect = reader["DefectName"].ToString(),
                            Date = reader["DateTime"].ToString(),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            ModelCode = reader["ModelCode"].ToString(),
                            SerialNumber = reader["SerialNumber"].ToString(),
                            LocationId = reader["LocationId"].ToString(),
                            Inspector = reader["InspectorName"].ToString()
                        };
                        resultList.Add(resultModel);
                    }
                }
            }

            return resultList;
        }

        public void Add(dynamic model)
        {
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Defect_Results (DateTime, SerialNumber, ModelCode, DefectId, InspectorId, ModelNumber, LocationId) values (@DateTime, @SerialNumber, @ModelCode, @DefectId, @InspectorId, @ModelNumber, @LocationId)";
                command.Parameters.Add("@DateTime", SqlDbType.SmallDateTime).Value = DateTime.Now;
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = model.SerialNumber;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;
                command.Parameters.Add("@DefectId", SqlDbType.Int).Value = model.DefectId;
                command.Parameters.Add("@InspectorId", SqlDbType.VarChar).Value = model.InspectorId;
                command.Parameters.Add("@ModelNumber", SqlDbType.VarChar).Value = model.ModelNumber;
                command.Parameters.Add("@LocationId", SqlDbType.Int).Value = model.Location;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DefectModel> GetAll()
        {
            var defectList = new List<DefectModel>();
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Defect_Names.Id, Parts.PartName, Defect_Names.DefectName " +
                              "FROM Defect_Names " +
                              "INNER JOIN Parts ON Defect_Names.PartId = Parts.Id " +
                                "ORDER BY Priority DESC ,DefectName ASC";
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
            using (var connection = new SqlConnection(DBConnection))
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
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Defect_Names.Id, Parts.PartName, Defect_Names.DefectName " +
                              "FROM Defect_Names " +
                              "INNER JOIN Parts ON Defect_Names.PartId = Parts.Id " +
                               "WHERE Parts.ChartId = @selectedId " + "ORDER BY Parts.PartName ASC, Priority DESC";
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
