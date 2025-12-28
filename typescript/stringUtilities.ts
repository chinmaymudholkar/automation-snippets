/**
 * String generation and manipulation utility functions for test automation
 */

import { v4 as uuidv4 } from 'uuid';

/**
 * Generate a random string of specified length
 * @param length - Length of the random string
 * @returns Random alphanumeric string
 */
export function generateRandomString(length: number = 10): string {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';
    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * characters.length));
    }
    return result;
}

/**
 * Generate a random integer string of specified length
 * @param length - Length of the random integer string
 * @returns Random integer string
 */
export function generateRandomInteger(length: number = 10): string {
    const digits = '0123456789';
    let result = '';
    for (let i = 0; i < length; i++) {
        result += digits.charAt(Math.floor(Math.random() * digits.length));
    }
    return result;
}

/**
 * Generate a unique identifier (UUID)
 * @returns UUID string
 */
export function generateUUID(): string {
    return uuidv4();
}
