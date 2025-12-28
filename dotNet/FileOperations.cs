using System;
using System.IO;
using System.Data;

namespace TestAutomation.Utils
{
    /// <summary>
    /// File I/O utility functions for test automation
    /// </summary>
    public static class FileOperations
    {
        /// <summary>
        /// Read a text file and return its contents
        /// </summary>
        /// <param name="filePath">Path to the text file</param>
        /// <returns>File contents as a string</returns>
        public static string ReadTextFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Read a text file and return its contents as an array of lines
        /// </summary>
        /// <param name="filePath">Path to the text file</param>
        /// <returns>Array of lines from the file</returns>
        public static string[] ReadTextFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        /// <summary>
        /// Write content to a text file
        /// </summary>
        /// <param name="filePath">Path to the text file</param>
        /// <param name="content">Content to write</param>
        public static void WriteTextFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        /// <summary>
        /// Append content to a text file
        /// </summary>
        /// <param name="filePath">Path to the text file</param>
        /// <param name="content">Content to append</param>
        public static void AppendToTextFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        /// <summary>
        /// Check if a file exists
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>true if file exists, false otherwise</returns>
        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Delete a file if it exists
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>true if file was deleted, false otherwise</returns>
        public static bool DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get the size of a file in bytes
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>File size in bytes</returns>
        public static long GetFileSize(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return fileInfo.Length;
        }

        /// <summary>
        /// Get file extension from file path
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>File extension (without dot)</returns>
        public static string GetFileType(string filePath)
        {
            return Path.GetExtension(filePath).TrimStart('.');
        }

        /// <summary>
        /// Get file name without extension
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>File name without extension</returns>
        public static string GetFileNameWithoutExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        /// <summary>
        /// Load a CSV file into a DataTable
        /// </summary>
        /// <param name="filePath">Path to the CSV file</param>
        /// <param name="hasHeader">True if the CSV has a header row</param>
        /// <returns>DataTable containing the CSV data</returns>
        public static DataTable LoadCsvToDataTable(string filePath, bool hasHeader = true)
        {
            DataTable dataTable = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0) return dataTable;

            string[] headers = lines[0].Split(',');
            int colCount = headers.Length;

            for (int i = 0; i < colCount; i++)
            {
                string columnName = hasHeader ? headers[i] : $"Column{i}";
                dataTable.Columns.Add(columnName);
            }

            int startRow = hasHeader ? 1 : 0;
            for (int i = startRow; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(',');
                DataRow dataRow = dataTable.NewRow();
                for (int j = 0; j < colCount; j++)
                {
                    dataRow[j] = rows[j];
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
