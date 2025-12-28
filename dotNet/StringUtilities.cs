using System;
using System.Linq;

namespace TestAutomation.Utils
{
    /// <summary>
    /// String generation and manipulation utility functions for test automation
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Generate a random string of specified length
        /// </summary>
        /// <param name="length">Length of the random string</param>
        /// <returns>Random alphanumeric string</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generate a random integer of specified length
        /// </summary>
        /// <param name="length">Length of the random integer string</param>
        /// <returns>Random integer string</returns>
        public static string GenerateRandomInteger(int length)
        {
            const string digits = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(digits, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generate a unique identifier (GUID)
        /// </summary>
        /// <returns>GUID string</returns>
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
