import java.util.Random;
import java.util.UUID;

/**
 * String generation and manipulation utility functions for test automation
 */
public class StringUtilities {

    /**
     * Generate a random string of specified length
     * 
     * @param length Length of the random string
     * @return Random alphanumeric string
     */
    public static String generateRandomString(int length) {
        String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++) {
            result.append(characters.charAt(random.nextInt(characters.length())));
        }
        return result.toString();
    }

    /**
     * Generate a random integer string of specified length
     * 
     * @param length Length of the random integer string
     * @return Random integer string
     */
    public static String generateRandomInteger(int length) {
        String digits = "0123456789";
        Random random = new Random();
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++) {
            result.append(digits.charAt(random.nextInt(digits.length())));
        }
        return result.toString();
    }

    /**
     * Generate a unique identifier (UUID)
     * 
     * @return UUID string
     */
    public static String generateUUID() {
        return UUID.randomUUID().toString();
    }
}
