﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

// Connect to SQL Server
namespace Project01_ATMT
{
    public class DataProvider // Provide a Connection to Database
    {
        // Create Connection
        private string connectionSTR = "Data Source=" + System.Windows.Forms.SystemInformation.ComputerName + ";Initial Catalog=newBD_Account;Integrated Security=True";
        
        // Query Execution
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR)) // Connect to SQL Server
            {
                connection.Open();

                // Create command
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); // Split each parameter
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) // Sign to recognize Command of Queries
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command); // Fill up dataset for SQL Server Database

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }
        
        // Transact-SQL Statement Execution
        /*public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            // Create Connection
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                // Create Command
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); // Split each parameter
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) // Sign to recognize Command of Queries
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }*/

       /* public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }*/ 
    }
}
