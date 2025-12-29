# .NET (C#) Utility Library

A collection of reusable utility functions for test automation in .NET (C#).

## Features

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

---

## Duration Format Examples

The `WaitForDuration` function allows specifying the required duration in a human-readable format.  Here are some examples:

| Duration String | Meaning |
|----------------|---------|
| `"30s"` | 30 seconds |
| `"5m"` | 5 minutes |
| `"2h"` | 2 hours |
| `"1d"` | 1 day |
| `"1h30m"` | 1 hour and 30 minutes |
| `"2d5h10m"` | 2 days, 5 hours, and 10 minutes |
| `"1d12h30m45s"` | 1 day, 12 hours, 30 minutes, and 45 seconds |

The supported units are:
- `d` or `D` - Days
- `h` or `H` - Hours
- `m` or `M` - Minutes
- `s` or `S` - Seconds

---

## Example Usage

### Test Report Organization
```csharp
string reportDir = DirectoryOperations.JoinPaths(
    DirectoryOperations.GetRootFolderPath(), 
    "test-reports", 
    DateTimeOperations.GetTodayDate("yyyy-MM-dd")
);
DirectoryOperations.CreateDirectory(reportDir);
```
