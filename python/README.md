# Python Utility Library

A collection of reusable utility functions for test automation in Python.

## Features

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

---

## Duration Format Examples

The `wait_for_duration` function allows specifying the required duration in a human-readable format.  Here are some examples:

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

### 1. Dynamic Test Data Generation
```python
# Generate unique test user
user_id = generate_random_string(8)
email = f"test_{user_id}@example.com"
```

### 2. Smart Test Delays
```python
# Wait for different durations based on test scenario
wait_for_duration("30s")  # Quick wait
wait_for_duration("5m")   # Medium wait
wait_for_duration("1h")   # Long wait for batch jobs
```
