# Test Automation Utility Library

A comprehensive collection of reusable utility functions for test automation across Java, .NET (C#), Python, and TypeScript.

## Features

### Java

| Category | Function Name | Short Description of the function |
| :--- | :--- | :--- |
| **DateTime** | `getTodayDate` | Get today's date in specified format |
| | `getCurrentTimestamp` | Get current timestamp in specified format |
| | `waitFor` | Pause execution for specified milliseconds |
| | `waitForDuration` | Pause execution for human-readable duration |
| **File** | `readTextFile` | Read entire text file content |
| | `readTextFileLines` | Read text file line by line |
| | `writeTextFile` | Write content to a text file |
| | `fileExists` | Check if file exists |
| | `deleteFile` | Delete file if it exists |
| | `getFileSize` | Get file size in bytes |
| | `getFileExtension` | Extract file extension |
| | `getFileNameWithoutExtension` | Get filename without extension |
| **Directory** | `getRootFolderName` | Get project root folder name |
| | `getRootFolderPath` | Get project root folder path |
| | `createDirectory` | Create directory and parents |
| | `joinPaths` | Combine path segments safely |
| **String** | `generateRandomString` | Create random alphanumeric string |
| | `generateRandomInteger` | Create random numeric string |
| | `generateUUID` | Create unique identifier |
| **Database** | `queryDatabase` | Run SQL query and return rows |
| | `executeNonQuery` | Execute INSERT/UPDATE/DELETE |
| | `executeScalar` | Get first column of first row |
| | `getTableNames` | Get list of all table names |
| | `tableExists` | Check if table exists |
| | `getRowCount` | Get row count of table or query |

### .NET (C#)

| Category | Function Name | Short Description of the function |
| :--- | :--- | :--- |
| **DateTime** | `GetTodayDate` | Get today's date in specified format |
| | `GetCurrentTimestamp` | Get current timestamp in specified format |
| | `WaitFor` | Pause execution for specified milliseconds |
| | `WaitForDuration` | Pause execution for human-readable duration |
| **File** | `ReadTextFile` | Read entire text file content |
| | `ReadTextFileLines` | Read text file line by line |
| | `WriteTextFile` | Write content to a text file |
| | `AppendToTextFile` | Append content to existing file |
| | `FileExists` | Check if file exists |
| | `DeleteFile` | Delete file if it exists |
| | `GetFileSize` | Get file size in bytes |
| | `GetFileType` | Get file extension |
| | `GetFileNameWithoutExtension` | Get filename without extension |
| | `LoadCsvToDataTable` | Load CSV file into DataTable |
| **Directory** | `GetRootFolderName` | Get project root folder name |
| | `GetRootFolderPath` | Get project root folder path |
| | `CreateDirectory` | Create directory if it doesn't exist |
| | `DirectoryExists` | Check if directory exists |
| | `GetFilesInDirectory` | List files with optional filter |
| | `JoinPaths` | Combine path segments safely |
| **String** | `GenerateRandomString` | Create random alphanumeric string |
| | `GenerateRandomInteger` | Create random numeric string |
| | `GenerateGuid` | Create unique identifier |
| **Database** | `QueryDatabase` | Run SQL query and return results |
| | `ExecuteNonQuery` | Execute INSERT/UPDATE/DELETE |
| | `ExecuteScalar` | Get first column of first row |
| | `GetTableNames` | Get list of all table names |
| | `TableExists` | Check if table exists |
| | `GetRowCount` | Get row count of table or query |

### Python

| Category | Function Name | Short Description of the function |
| :--- | :--- | :--- |
| **DateTime** | `get_today_date` | Get today's date in specified format |
| | `get_current_timestamp` | Get current timestamp in specified format |
| | `wait_for` | Pause execution for specified seconds |
| | `wait_for_duration` | Pause execution for human-readable duration |
| **File** | `read_text_file` | Read entire text file content |
| | `read_text_file_lines` | Read text file line by line |
| | `write_text_file` | Write content to a text file |
| | `append_to_text_file` | Append content to existing file |
| | `file_exists` | Check if file exists |
| | `delete_file` | Delete file if it exists |
| | `get_file_size` | Get file size in bytes |
| | `get_file_extension` | Extract file extension |
| | `get_file_name_without_extension` | Get filename without extension |
| | `load_csv_to_dataframe` | Load CSV file into DataFrame |
| **Directory** | `get_root_folder_name` | Get project root folder name |
| | `get_root_folder_path` | Get project root folder path |
| | `create_directory` | Create directory if it doesn't exist |
| | `directory_exists` | Check if directory exists |
| | `get_files_in_directory` | List files with optional filter |
| | `join_paths` | Combine path segments safely |
| | `get_absolute_path` | Convert relative to absolute path |
| | `get_parent_directory` | Get parent directory path |
| **String** | `generate_random_string` | Create random alphanumeric string |
| | `generate_random_integer` | Create random numeric string |
| | `generate_uuid` | Create unique identifier |
| **Database** | `query_database` | Run SQL query and return DataFrame |
| | `execute_non_query_statement` | Execute INSERT/UPDATE/DELETE |
| | `execute_scalar` | Get first column of first row |
| | `get_table_names` | Get list of all table names |
| | `table_exists` | Check if table exists |
| | `get_row_count` | Get row count of table or query |

### TypeScript

| Category | Function Name | Short Description of the function |
| :--- | :--- | :--- |
| **DateTime** | `getTodayDate` | Get today's date in specified format |
| | `getCurrentTimestamp` | Get current timestamp in specified format |
| | `waitFor` | Pause execution for specified milliseconds |
| | `waitForDuration` | Pause execution for human-readable duration |
| **File** | `readTextFile` | Read entire text file content |
| | `readTextFileLines` | Read text file line by line |
| | `writeTextFile` | Write content to a text file |
| | `appendToTextFile` | Append content to existing file |
| | `fileExists` | Check if file exists |
| | `deleteFile` | Delete file if it exists |
| | `getFileSize` | Get file size in bytes |
| | `getFileExtension` | Extract file extension |
| | `getFileNameWithoutExtension` | Get filename without extension |
| **Directory** | `getRootFolderName` | Get project root folder name |
| | `getRootFolderPath` | Get project root folder path |
| | `createDirectory` | Create directory if it doesn't exist |
| | `directoryExists` | Check if directory exists |
| | `getFilesInDirectory` | List files with optional filter |
| | `joinPaths` | Combine path segments safely |
| | `getAbsolutePath` | Convert relative to absolute path |
| | `getParentDirectory` | Get parent directory path |
| **String** | `generateRandomString` | Create random alphanumeric string |
| | `generateRandomInteger` | Create random numeric string |
| | `generateUUID` | Create unique identifier |
| **Database** | `queryDatabase` | Run SQL query and return results |
| | `executeNonQuery` | Execute INSERT/UPDATE/DELETE |
| | `executeScalar` | Get first column of first row |
| | `getTableNames` | Get list of all table names |
| | `tableExists` | Check if table exists |
| | `getRowCount` | Get row count of table or query |

---

## Duration Format Examples

The `waitForDuration` function supports flexible duration strings:

| Duration String | Meaning |
|----------------|---------|
| `"30s"` | 30 seconds |
| `"5m"` | 5 minutes |
| `"2h"` | 2 hours |
| `"1d"` | 1 day |
| `"1h30m"` | 1 hour and 30 minutes |
| `"2d5h10m"` | 2 days, 5 hours, and 10 minutes |
| `"1d12h30m45s"` | 1 day, 12 hours, 30 minutes, and 45 seconds |

**Supported units:**
- `d` or `D` - Days
- `h` or `H` - Hours
- `m` or `M` - Minutes
- `s` or `S` - Seconds

---

## Setup Instructions

Copy and use the functions directly in your code **OR** to use all the functions copy the files to your project:

### Java
1. Copy all `.java` files to your project's `src/main/java/utils/` directory
2. Import the classes you need:
   ```java
   import utils.DateTimeOperations;
   import utils.FileOperations;
   import utils.DirectoryOperations;
   import utils.StringUtilities;
   import utils.DatabaseOperations;
   ```

### .NET (C#)
1. Copy all `.cs` files to your project
2. Add namespace:
   ```csharp
   using TestAutomation.Utils;
   ```

### Python
1. Copy all `.py` files to your project directory
2. Import the modules you need:
   ```python
   from datetime_operations import *
   from file_operations import *
   from directory_operations import *
   from string_utilities import *
   from database_operations import *
   ```

### TypeScript
1. Copy all TypeScript files to your project
2. Install dependencies:
   ```bash
   cd typescript
   npm install
   ```
3. Build the project:
   ```bash
   npm run build
   ```
4. Import and use:
   ```typescript
   import * as DateTimeOps from './dateTimeOperations';
   import * as FileOps from './fileOperations';
   import * as DirOps from './directoryOperations';
   import * as StringUtils from './stringUtilities';
   import * as DbOps from './databaseOperations';
   ```

---

## Common Use Cases in Test Automation

### 1. **Dynamic Test Data Generation**
```python
# Generate unique test user
user_id = generate_random_string(8)
email = f"test_{user_id}@example.com"
```

### 2. **Screenshot Naming with Timestamps**
```java
String screenshotName = "screenshot_" + DateTimeOperations.getCurrentTimestamp("yyyyMMdd_HHmmss") + ".png";
```

### 3. **Test Report Organization**
```csharp
string reportDir = DirectoryOperations.JoinPaths(
    DirectoryOperations.GetRootFolderPath(), 
    "test-reports", 
    DateTimeOperations.GetTodayDate("yyyy-MM-dd")
);
DirectoryOperations.CreateDirectory(reportDir);
```

### 4. **Configuration File Reading**
```typescript
const configPath = DirOps.joinPaths(DirOps.getRootFolderPath(), "config", "test-config.json");
const config = JSON.parse(FileOps.readTextFile(configPath));
```

### 5. **Smart Test Delays**
```python
# Wait for different durations based on test scenario
wait_for_duration("30s")  # Quick wait
wait_for_duration("5m")   # Medium wait
wait_for_duration("1h")   # Long wait for batch jobs
```

---

## Best Practices For Utility Functions

1. **Modular Imports**: Import only the utility modules you need
2. **Consistent Date Formats**: Use ISO 8601 format (`yyyy-MM-dd`) for dates in logs and reports
3. **Path Handling**: Always use path joining functions instead of string concatenation
4. **Error Handling**: Wrap file and database operations in try-catch blocks
5. **Unique Identifiers**: Use UUID/GUID for unique test data instead of timestamps
6. **Duration Strings**: Use human-readable duration strings for better test readability

---

## License

MIT License - Feel free to use and modify for your test automation projects.

---

## Contributing

Feel free to add more utility functions as needed for your test automation harness. Keep functions:
- **Simple**: Single responsibility
- **Reusable**: Generic and parameterized
- **Documented**: Clear docstrings/comments
- **Consistent**: Follow language conventions
- **Organized**: Group by theme (DateTime, File, Directory, String, Database)
