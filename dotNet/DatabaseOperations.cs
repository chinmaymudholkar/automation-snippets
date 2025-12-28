using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TestAutomation.Utils
{
    /// <summary>
    /// SQL Server database operations utility functions for test automation
    /// </summary>
    public static class DatabaseOperations
    {
        /// <summary>
        /// Run a query on a SQL Server database and return the results
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <param name="query">SQL query to execute</param>
        /// <returns>DataTable containing the query results</returns>
        public static DataTable QueryDatabase(string connectionString, string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
                throw;
            }
            finally
            {
                // Additional cleanup if needed
            }
        }

        /// <summary>
        /// Execute a non-query SQL statement (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <param name="statement">SQL statement to execute</param>
        /// <param name="params">Parameters for the statement</param>
        /// <returns>Number of affected rows</returns>
        public static int ExecuteNonQuery(string connectionString, string statement, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(statement, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing non-query: {ex.Message}");
                throw;
            }
            finally
            {
                // Additional cleanup if needed
            }
        }

        /// <summary>
        /// Execute a query and return the first column of the first row
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <param name="query">SQL query to execute</param>
        /// <param name="params">Parameters for the query</param>
        /// <returns>The value of the first column of the first row, or null</returns>
        public static object ExecuteScalar(string connectionString, string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing scalar: {ex.Message}");
                throw;
            }
            finally
            {
                // Additional cleanup if needed
            }
        }

        /// <summary>
        /// Get a list of all tables in the database
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <returns>List of table names</returns>
        public static List<string> GetTableNames(string connectionString)
        {
            List<string> tableNames = new List<string>();
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            DataTable dt = QueryDatabase(connectionString, query);
            foreach (DataRow row in dt.Rows)
            {
                tableNames.Add(row["TABLE_NAME"].ToString());
            }
            return tableNames;
        }

        /// <summary>
        /// Check if a table exists in the database
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <param name="tableName">Name of the table to check</param>
        /// <returns>True if table exists, False otherwise</returns>
        public static bool TableExists(string connectionString, string tableName)
        {
            string query = "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName AND TABLE_TYPE = 'BASE TABLE'";
            var param = new SqlParameter("@tableName", tableName);
            object result = ExecuteScalar(connectionString, query, param);
            return result != null;
        }

        /// <summary>
        /// Get the row count of a table or query
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        /// <param name="tableOrQuery">Name of the table or a SQL SELECT query</param>
        /// <returns>Number of rows</returns>
        public static long GetRowCount(string connectionString, string tableOrQuery)
        {
            string query;
            if (tableOrQuery.Trim().ToUpper().StartsWith("SELECT"))
            {
                query = $"SELECT COUNT(1) FROM ({tableOrQuery}) AS subquery";
            }
            else
            {
                query = $"SELECT COUNT(1) FROM {tableOrQuery}";
            }
            
            object result = ExecuteScalar(connectionString, query);
            return Convert.ToInt64(result);
        }
    }
}
