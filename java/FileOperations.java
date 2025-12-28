import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;

/**
 * File I/O utility functions for test automation
 */
public class FileOperations {

    /**
     * Read a text file and return its contents
     * 
     * @param filePath Path to the text file
     * @return File contents as a string
     * @throws IOException If file cannot be read
     */
    public static String readTextFile(String filePath) throws IOException {
        Path path = Paths.get(filePath);
        return Files.readString(path);
    }

    /**
     * Read a text file and return its contents as a list of lines
     * 
     * @param filePath Path to the text file
     * @return List of lines from the file
     * @throws IOException If file cannot be read
     */
    public static List<String> readTextFileLines(String filePath) throws IOException {
        Path path = Paths.get(filePath);
        return Files.readAllLines(path);
    }

    /**
     * Write content to a text file
     * 
     * @param filePath Path to the text file
     * @param content  Content to write
     * @throws IOException If file cannot be written
     */
    public static void writeTextFile(String filePath, String content) throws IOException {
        Path path = Paths.get(filePath);
        Files.writeString(path, content);
    }

    /**
     * Check if a file exists
     * 
     * @param filePath Path to the file
     * @return true if file exists, false otherwise
     */
    public static boolean fileExists(String filePath) {
        return Files.exists(Paths.get(filePath));
    }

    /**
     * Delete a file if it exists
     * 
     * @param filePath Path to the file
     * @return true if file was deleted, false otherwise
     * @throws IOException If file cannot be deleted
     */
    public static boolean deleteFile(String filePath) throws IOException {
        Path path = Paths.get(filePath);
        return Files.deleteIfExists(path);
    }

    /**
     * Get the size of a file in bytes
     * 
     * @param filePath Path to the file
     * @return File size in bytes
     * @throws IOException If file size cannot be determined
     */
    public static long getFileSize(String filePath) throws IOException {
        Path path = Paths.get(filePath);
        return Files.size(path);
    }

    /**
     * Get file extension from file path
     * 
     * @param filePath Path to the file
     * @return File extension (without dot)
     */
    public static String getFileExtension(String filePath) {
        int lastDotIndex = filePath.lastIndexOf('.');
        if (lastDotIndex > 0 && lastDotIndex < filePath.length() - 1) {
            return filePath.substring(lastDotIndex + 1);
        }
        return "";
    }

    /**
     * Get file name without extension
     * 
     * @param filePath Path to the file
     * @return File name without extension
     */
    public static String getFileNameWithoutExtension(String filePath) {
        File file = new File(filePath);
        String fileName = file.getName();
        int lastDotIndex = fileName.lastIndexOf('.');
        if (lastDotIndex > 0) {
            return fileName.substring(0, lastDotIndex);
        }
        return fileName;
    }
}
