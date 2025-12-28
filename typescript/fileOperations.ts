/**
 * File I/O utility functions for test automation
 */

import * as fs from 'fs';
import * as path from 'path';

/**
 * Read a text file and return its contents
 * @param filePath - Path to the text file
 * @returns File contents as a string
 */
export function readTextFile(filePath: string): string {
    return fs.readFileSync(filePath, 'utf-8');
}

/**
 * Read a text file and return its contents as an array of lines
 * @param filePath - Path to the text file
 * @returns Array of lines from the file
 */
export function readTextFileLines(filePath: string): string[] {
    const content = fs.readFileSync(filePath, 'utf-8');
    return content.split('\n');
}

/**
 * Write content to a text file
 * @param filePath - Path to the text file
 * @param content - Content to write
 */
export function writeTextFile(filePath: string, content: string): void {
    fs.writeFileSync(filePath, content, 'utf-8');
}

/**
 * Append content to a text file
 * @param filePath - Path to the text file
 * @param content - Content to append
 */
export function appendToTextFile(filePath: string, content: string): void {
    fs.appendFileSync(filePath, content, 'utf-8');
}

/**
 * Check if a file exists
 * @param filePath - Path to the file
 * @returns true if file exists, false otherwise
 */
export function fileExists(filePath: string): boolean {
    return fs.existsSync(filePath) && fs.statSync(filePath).isFile();
}

/**
 * Delete a file if it exists
 * @param filePath - Path to the file
 * @returns true if file was deleted, false otherwise
 */
export function deleteFile(filePath: string): boolean {
    if (fs.existsSync(filePath)) {
        fs.unlinkSync(filePath);
        return true;
    }
    return false;
}

/**
 * Get the size of a file in bytes
 * @param filePath - Path to the file
 * @returns File size in bytes
 */
export function getFileSize(filePath: string): number {
    const stats = fs.statSync(filePath);
    return stats.size;
}

/**
 * Get file extension from file path
 * @param filePath - Path to the file
 * @returns File extension (without dot)
 */
export function getFileExtension(filePath: string): string {
    return path.extname(filePath).substring(1);
}

/**
 * Get file name without extension
 * @param filePath - Path to the file
 * @returns File name without extension
 */
export function getFileNameWithoutExtension(filePath: string): string {
    return path.basename(filePath, path.extname(filePath));
}
