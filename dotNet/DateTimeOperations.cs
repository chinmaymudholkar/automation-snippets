using System;
using System.Threading;

namespace TestAutomation.Utils
{
    /// <summary>
    /// Date and time utility functions for test automation
    /// </summary>
    public static class DateTimeOperations
    {
        /// <summary>
        /// Get today's date in the specified format
        /// </summary>
        /// <param name="format">Date format pattern (e.g., "yyyy-MM-dd", "MM/dd/yyyy", "dd-MMM-yyyy")</param>
        /// <returns>Formatted date string</returns>
        public static string GetTodayDate(string format)
        {
            return DateTime.Now.ToString(format);
        }

        /// <summary>
        /// Get current timestamp in the specified format
        /// </summary>
        /// <param name="format">Timestamp format pattern (e.g., "yyyy-MM-dd HH:mm:ss", "yyyyMMdd_HHmmss")</param>
        /// <returns>Formatted timestamp string</returns>
        public static string GetCurrentTimestamp(string format)
        {
            return DateTime.Now.ToString(format);
        }

        /// <summary>
        /// Wait for specified milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to wait in milliseconds</param>
        public static void WaitFor(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        /// <summary>
        /// Wait for a duration specified in a human-readable format
        /// Supports: d (days), h (hours), m (minutes), s (seconds)
        /// Examples: "2d5h10m", "30m", "1h30m", "2d", "45s"
        /// </summary>
        /// <param name="duration">Duration string (e.g., "2d5h10m")</param>
        public static void WaitForDuration(string duration)
        {
            long totalMilliseconds = ParseDuration(duration);
            Thread.Sleep((int)totalMilliseconds);
        }

        /// <summary>
        /// Parse a duration string into milliseconds
        /// </summary>
        /// <param name="duration">Duration string (e.g., "2d5h10m30s")</param>
        /// <returns>Total milliseconds</returns>
        private static long ParseDuration(string duration)
        {
            long totalMilliseconds = 0;
            var numberBuffer = new System.Text.StringBuilder();

            foreach (char c in duration)
            {
                if (char.IsDigit(c))
                {
                    numberBuffer.Append(c);
                }
                else
                {
                    if (numberBuffer.Length > 0)
                    {
                        long value = long.Parse(numberBuffer.ToString());

                        switch (char.ToLower(c))
                        {
                            case 'd':
                                totalMilliseconds += value * 24 * 60 * 60 * 1000;
                                break;
                            case 'h':
                                totalMilliseconds += value * 60 * 60 * 1000;
                                break;
                            case 'm':
                                totalMilliseconds += value * 60 * 1000;
                                break;
                            case 's':
                                totalMilliseconds += value * 1000;
                                break;
                            default:
                                throw new ArgumentException($"Invalid duration unit: {c}");
                        }

                        numberBuffer.Clear();
                    }
                }
            }

            return totalMilliseconds;
        }
    }
}
