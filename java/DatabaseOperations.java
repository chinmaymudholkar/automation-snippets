import java.sql.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * PostgreSQL database operations utility functions for test automation using
 * JDBC
 */
public class DatabaseOperations {

    /**
     * Run a query on a PostgreSQL database and return the results
     * 
     * @param connectionString - Postgres connection URL (e.g.,
     *                         jdbc:postgresql://host:port/db)
     * @param user             - Database username
     * @param password         - Database password
     * @param query            - SQL query to execute
     * @return List of maps, each map representing a row
     * @throws SQLException - If a database access error occurs
     */
    public static List<Map<String, Object>> queryDatabase(String connectionString, String user, String password,
            String query) throws SQLException {
        List<Map<String, Object>> results = new ArrayList<>();
        try (Connection conn = DriverManager.getConnection(connectionString, user, password);
                Statement stmt = conn.createStatement();
                ResultSet rs = stmt.executeQuery(query)) {

            ResultSetMetaData metaData = rs.getMetaData();
            int columnCount = metaData.getColumnCount();

            while (rs.next()) {
                Map<String, Object> row = new HashMap<>();
                for (int i = 1; i <= columnCount; i++) {
                    row.put(metaData.getColumnName(i), rs.getObject(i));
                }
                results.add(row);
            }
        } catch (SQLException e) {
            System.err.println("Error executing query: " + e.getMessage());
            throw e;
        } finally {
            // Additional cleanup if needed
        }
        return results;
    }

    /**
     * Execute a non-query SQL statement (INSERT, UPDATE, DELETE)
     * 
     * @param connectionString - Postgres connection URL
     * @param user             - Database username
     * @param password         - Database password
     * @param statement        - SQL statement to execute
     * @param params           - Parameters for the statement
     * @return Number of affected rows
     * @throws SQLException - If a database access error occurs
     */
    public static int executeNonQuery(String connectionString, String user, String password, String statement,
            Object... params) throws SQLException {
        try (Connection conn = DriverManager.getConnection(connectionString, user, password);
                PreparedStatement pstmt = conn.prepareStatement(statement)) {

            for (int i = 0; i < params.length; i++) {
                pstmt.setObject(i + 1, params[i]);
            }
            return pstmt.executeUpdate();
        } catch (SQLException e) {
            System.err.println("Error executing non-query: " + e.getMessage());
            throw e;
        } finally {
            // Additional cleanup if needed
        }
    }

    /**
     * Execute a query and return the first column of the first row
     * 
     * @param connectionString - Postgres connection URL
     * @param user             - Database username
     * @param password         - Database password
     * @param query            - SQL query to execute
     * @param params           - Parameters for the query
     * @return The value of the first column of the first row, or null
     * @throws SQLException - If a database access error occurs
     */
    public static Object executeScalar(String connectionString, String user, String password, String query,
            Object... params) throws SQLException {
        try (Connection conn = DriverManager.getConnection(connectionString, user, password);
                PreparedStatement pstmt = conn.prepareStatement(query)) {

            for (int i = 0; i < params.length; i++) {
                pstmt.setObject(i + 1, params[i]);
            }

            try (ResultSet rs = pstmt.executeQuery()) {
                if (rs.next()) {
                    return rs.getObject(1);
                }
            } catch (SQLException e) {
                System.err.println("Error processing result set: " + e.getMessage());
                throw e;
            } finally {
                // Additional cleanup if needed
            }
        } catch (SQLException e) {
            System.err.println("Error executing scalar: " + e.getMessage());
            throw e;
        } finally {
            // Additional cleanup if needed
        }
        return null;
    }

    /**
     * Get a list of all tables in the public schema
     * 
     * @param connectionString - Postgres connection URL
     * @param user             - Database username
     * @param password         - Database password
     * @return List of table names
     * @throws SQLException - If a database access error occurs
     */
    public static List<String> getTableNames(String connectionString, String user, String password)
            throws SQLException {
        List<String> tableNames = new ArrayList<>();
        String query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'";
        List<Map<String, Object>> rows = queryDatabase(connectionString, user, password, query);
        for (Map<String, Object> row : rows) {
            tableNames.add(row.get("table_name").toString());
        }
        return tableNames;
    }

    /**
     * Check if a table exists in the public schema
     * 
     * @param connectionString - Postgres connection URL
     * @param user             - Database username
     * @param password         - Database password
     * @param tableName        - Name of the table to check
     * @return True if table exists, False otherwise
     * @throws SQLException - If a database access error occurs
     */
    public static boolean tableExists(String connectionString, String user, String password, String tableName)
            throws SQLException {
        String query = "SELECT EXISTS (SELECT FROM information_schema.tables WHERE table_schema = 'public' AND table_name = ?)";
        Object result = executeScalar(connectionString, user, password, query, tableName);
        return result != null && (Boolean) result;
    }

    /**
     * Get the row count of a table or query
     * 
     * @param connectionString - Postgres connection URL
     * @param user             - Database username
     * @param password         - Database password
     * @param tableOrQuery     - Name of the table or a SQL SELECT query
     * @return Number of rows
     * @throws SQLException - If a database access error occurs
     */
    public static long getRowCount(String connectionString, String user, String password, String tableOrQuery)
            throws SQLException {
        String query;
        if (tableOrQuery.trim().toUpperCase().startsWith("SELECT")) {
            query = String.format("SELECT COUNT(1) FROM (%s) AS subquery", tableOrQuery);
        } else {
            query = String.format("SELECT COUNT(1) FROM %s", tableOrQuery);
        }

        Object result = executeScalar(connectionString, user, password, query);
        return (result instanceof Number) ? ((Number) result).longValue() : 0;
    }
}
