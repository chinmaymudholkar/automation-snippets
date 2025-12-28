import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

/**
 * Directory and path utility functions for test automation
 */
public class DirectoryOperations {

    /**
     * Get the root folder name of the project
     * 
     * @return Root folder name
     */
    public static String getRootFolderName() {
        return new File(System.getProperty("user.dir")).getName();
    }

    /**
     * Get the root folder path of the project
     * 
     * @return Root folder absolute path
     */
    public static String getRootFolderPath() {
        return System.getProperty("user.dir");
    }

    /**
     * Create a directory if it doesn't exist
     * 
     * @param directoryPath Path to the directory
     * @throws IOException If directory cannot be created
     */
    public static void createDirectory(String directoryPath) throws IOException {
        Path path = Paths.get(directoryPath);
        if (!Files.exists(path)) {
            Files.createDirectories(path);
        }
    }

    /**
     * Join multiple path segments into a single path
     * 
     * @param paths Path segments to join
     * @return Combined path string
     */
    public static String joinPaths(String... paths) {
        return Paths.get("", paths).toString();
    }
}
