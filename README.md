# Test Automation Utility Library

## Introduction

This repo is a collection of reusable utility functions for test automation in multiple languages.  Whenever I've started working on any new test automation project over the years, I've usually had to write these utility functions over and over again.  So I've decided to create this repo to have a set of reusable utility functions to help with common tasks like file and directory operations, date and time handling, and database operations etc.  Please feel free to copy the files/functions you need for your test automation project and also contribute to this repo if you have any new functions that you think others might find useful.

## Covered Languages

Click on the links below to view the documentation and setup instructions for each language:

- [**Java**](java/README.md)
- [**.NET (C#)**](dotNet/README.md)
- [**Python**](python/README.md)
- [**TypeScript**](typescript/README.md)

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
