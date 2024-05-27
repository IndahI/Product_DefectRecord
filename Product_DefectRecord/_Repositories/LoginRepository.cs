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
            DBConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        public LoginModel GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Nik, Name, Password FROM Users WHERE Nik = @Nik";
                command.Parameters.Add("@Nik", SqlDbType.Int).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nik = reader["Nik"].ToString();
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