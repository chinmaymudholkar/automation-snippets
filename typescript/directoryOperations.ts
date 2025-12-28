/**
 * Directory and path utility functions for test automation
 */

import * as fs from 'fs';
import * as path from 'path';

/**
 * Get the root folder name of the project
 * @returns Root folder name
 */
export function getRootFolderName(): string {
    return path.basename(process.cwd());
}

/**
 * Get the root folder path of the project
 * @returns Root folder absolute path
 */
export function getRootFolderPath(): string {
    return process.cwd();
}

/**
 * Create a directory if it doesn't exist
 * @param directoryPath - Path to the directory
 */
export function createDirectory(directoryPath: string): void {
    if (!fs.existsSync(directoryPath)) {
        fs.mkdirSync(directoryPath, { recursive: true });
    }
}

/**
 * Check if a directory exists
 * @param directoryPath - Path to the directory
 * @returns true if directory exists, false otherwise
 */
export function directoryExists(directoryPath: string): boolean {
    return fs.existsSync(directoryPath) && fs.statSync(directoryPath).isDirectory();
}

/**
 * Get all files in a directory with optional filter
 * @param directoryPath - Path to the directory
 * @param extension - Optional file extension filter (e.g., ".txt")
 * @returns Array of file paths
 */
export function getFilesInDirectory(directoryPath: string, extension?: string): string[] {
    const files = fs.readdirSync(directoryPath);
    if (extension) {
        return files
            .filter(file => path.extname(file) === extension)
            .map(file => path.join(directoryPath, file));
    }
    return files.map(file => path.join(directoryPath, file));
}

/**
 * Join multiple path segments into a single path
 * @param paths - Path segments to join
 * @returns Combined path string
 */
export function joinPaths(...paths: string[]): string {
    return path.join(...paths);
}

/**
 * Get the absolute path from a relative path
 * @param relativePath - Relative path
 * @returns Absolute path
 */
export function getAbsolutePath(relativePath: string): string {
    return path.resolve(relativePath);
}

/**
 * Get the parent directory of a file or directory
 * @param filePath - Path to the file or directory
 * @returns Parent directory path
 */
export function getParentDirectory(filePath: string): string {
    return path.dirname(filePath);
}
