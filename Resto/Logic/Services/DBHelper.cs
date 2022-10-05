﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    public class DBHelper
    {
        public static SqlCommand command;
        // this method to get connection string from sql server
        private static SqlConnection getConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Properties.Settings.Default.ServerName;
            builder.InitialCatalog = Properties.Settings.Default.DBName;
            builder.IntegratedSecurity = true;
            return new SqlConnection(builder.ConnectionString);
        }
        // insert update deltete Data
        public static bool exceutedata(string spName, Action methoud)
        {
            // premierement recupere l'adresse
            using (SqlConnection connection = getConnectionString())
            {
                try
                {
                    command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    methoud.Invoke();

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return false;
        }
    }
}
