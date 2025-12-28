/**
 * Date and time utility functions for test automation
 */

/**
 * Get today's date in the specified format
 * @param format - Date format pattern (e.g., "YYYY-MM-DD", "MM/DD/YYYY", "DD-MMM-YYYY")
 * @returns Formatted date string
 */
export function getTodayDate(format: string = 'YYYY-MM-DD'): string {
    const now = new Date();
    return formatDate(now, format);
}

/**
 * Get current timestamp in the specified format
 * @param format - Timestamp format pattern (e.g., "YYYY-MM-DD HH:mm:ss", "YYYYMMDD_HHmmss")
 * @returns Formatted timestamp string
 */
export function getCurrentTimestamp(format: string = 'YYYY-MM-DD HH:mm:ss'): string {
    const now = new Date();
    return formatDate(now, format);
}

/**
 * Format a date according to the specified pattern
 * @param date - Date object to format
 * @param format - Format pattern
 * @returns Formatted date string
 */
function formatDate(date: Date, format: string): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    const seconds = String(date.getSeconds()).padStart(2, '0');

    return format
        .replace('YYYY', String(year))
        .replace('MM', month)
        .replace('DD', day)
        .replace('HH', hours)
        .replace('mm', minutes)
        .replace('ss', seconds);
}

/**
 * Wait for specified milliseconds
 * @param milliseconds - Time to wait in milliseconds
 * @returns Promise that resolves after the specified time
 */
export async function waitFor(milliseconds: number): Promise<void> {
    return new Promise<void>(resolve => setTimeout(resolve, milliseconds));
}

/**
 * Wait for a duration specified in a human-readable format
 * Supports: d (days), h (hours), m (minutes), s (seconds)
 * Examples: "2d5h10m", "30m", "1h30m", "2d", "45s"
 * @param duration - Duration string (e.g., "2d5h10m")
 * @returns Promise that resolves after the specified duration
 */
export async function waitForDuration(duration: string): Promise<void> {
    const totalMilliseconds = parseDuration(duration);
    return waitFor(totalMilliseconds);
}

/**
 * Parse a duration string into milliseconds
 * @param duration - Duration string (e.g., "2d5h10m30s")
 * @returns Total milliseconds
 */
function parseDuration(duration: string): number {
    let totalMilliseconds = 0;
    let numberBuffer = '';

    for (const char of duration) {
        if (/\d/.test(char)) {
            numberBuffer += char;
        } else {
            if (numberBuffer.length > 0) {
                const value = parseInt(numberBuffer, 10);

                switch (char.toLowerCase()) {
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
                        throw new Error(`Invalid duration unit: ${char}`);
                }

                numberBuffer = '';
            }
        }
    }

    return totalMilliseconds;
}


