# TypeScript Utility Library

A collection of reusable utility functions for test automation in TypeScript.

## Features

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

The `waitForDuration` function allows specifying the required duration in a human-readable format.  Here are some examples:

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

### Configuration File Reading
```typescript
const configPath = DirOps.joinPaths(DirOps.getRootFolderPath(), "config", "test-config.json");
const config = JSON.parse(FileOps.readTextFile(configPath));
```
