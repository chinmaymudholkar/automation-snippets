import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

/**
 * Date and time utility functions for test automation
 */
public class DateTimeOperations {

    /**
     * Get today's date in the specified format
     * 
     * @param format Date format pattern (e.g., "yyyy-MM-dd", "MM/dd/yyyy",
     *               "dd-MMM-yyyy")
     * @return Formatted date string
     */
    public static String getTodayDate(String format) {
        LocalDateTime now = LocalDateTime.now();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern(format);
        return now.format(formatter);
    }

    /**
     * Get current timestamp in the specified format
     * 
     * @param format Timestamp format pattern (e.g., "yyyy-MM-dd HH:mm:ss",
     *               "yyyyMMdd_HHmmss")
     * @return Formatted timestamp string
     */
    public static String getCurrentTimestamp(String format) {
        LocalDateTime now = LocalDateTime.now();
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern(format);
        return now.format(formatter);
    }

    /**
     * Wait for specified milliseconds
     * 
     * @param milliseconds Time to wait in milliseconds
     */
    public static void waitFor(long milliseconds) {
        try {
            Thread.sleep(milliseconds);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }

    /**
     * Wait for a duration specified in a human-readable format
     * Supports: d (days), h (hours), m (minutes), s (seconds)
     * Examples: "2d5h10m", "30m", "1h30m", "2d", "45s"
     * 
     * @param duration Duration string (e.g., "2d5h10m")
     */
    public static void waitForDuration(String duration) {
        long totalMilliseconds = parseDuration(duration);
        waitFor(totalMilliseconds);
    }

    /**
     * Parse a duration string into milliseconds
     * 
     * @param duration Duration string (e.g., "2d5h10m30s")
     * @return Total milliseconds
     */
    private static long parseDuration(String duration) {
        long totalMilliseconds = 0;
        StringBuilder numberBuffer = new StringBuilder();

        for (int i = 0; i < duration.length(); i++) {
            char c = duration.charAt(i);

            if (Character.isDigit(c)) {
                numberBuffer.append(c);
            } else {
                if (numberBuffer.length() > 0) {
                    long value = Long.parseLong(numberBuffer.toString());

                    switch (Character.toLowerCase(c)) {
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
                            throw new IllegalArgumentException("Invalid duration unit: " + c);
                    }

                    numberBuffer.setLength(0);
                }
            }
        }

        return totalMilliseconds;
    }
}
