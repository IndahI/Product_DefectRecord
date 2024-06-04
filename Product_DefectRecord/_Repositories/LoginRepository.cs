﻿using Product_DefectRecord.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_DefectRecord._Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private string DBConnection;
        public LoginRepository() 
        { 
            DBConnection = ConfigurationManager.ConnectionStrings["DBCommon"].ConnectionString;
        }

        public LoginModel GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT NikId, Name, Password FROM Users WHERE NikId = @Nik";
                command.Parameters.Add("@Nik", SqlDbType.Int).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nik = reader["NikId"].ToString();
                        string name = reader["Name"].ToString();
                        string password = reader["Password"].ToString();

                        return new LoginModel { Nik = nik, Name = name, Password = password };
                    }
                    else
                    {
                        return null; // Pengguna tidak ditemukan
                    }

                }
            }
        }
    }
}