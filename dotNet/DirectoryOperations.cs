using System;
using System.IO;

namespace TestAutomation.Utils
{
    /// <summary>
    /// Directory and path utility functions for test automation
    /// </summary>
    public static class DirectoryOperations
    {
        /// <summary>
        /// Get the root folder name of the project
        /// </summary>
        /// <returns>Root folder name</returns>
        public static string GetRootFolderName()
        {
            return new DirectoryInfo(Directory.GetCurrentDirectory()).Name;
        }

        /// <summary>
        /// Get the root folder path of the project
        /// </summary>
        /// <returns>Root folder absolute path</returns>
        public static string GetRootFolderPath()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Create a directory if it doesn't exist
        /// </summary>
        /// <param name="directoryPath">Path to the directory</param>
        public static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Check if a directory exists
        /// </summary>
        /// <param name="directoryPath">Path to the directory</param>
        /// <returns>true if directory exists, false otherwise</returns>
        public static bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        /// <summary>
        /// Get all files in a directory with optional search pattern
        /// </summary>
        /// <param name="directoryPath">Path to the directory</param>
        /// <param name="searchPattern">Search pattern (e.g., "*.txt")</param>
        /// <returns>Array of file paths</returns>
        public static string[] GetFilesInDirectory(string directoryPath, string searchPattern = "*.*")
        {
            return Directory.GetFiles(directoryPath, searchPattern);
        }

        /// <summary>
        /// Join multiple path segments into a single path
        /// </summary>
        /// <param name="paths">Path segments to join</param>
        /// <returns>Combined path string</returns>
        public static string JoinPaths(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}
