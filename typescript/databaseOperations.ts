/**
 * PostgreSQL database operations utility functions for test automation
 */

import { Client, QueryResult } from 'pg';

/**
 * Run a query on a PostgreSQL database and return the results
 * @param connectionString - Postgres connection string
 * @param query - SQL query to execute
 * @returns Array of rows as objects
 */
export async function queryDatabase(connectionString: string, query: string): Promise<any[]> {
    const client = new Client({ connectionString });
    try {
        await client.connect();
        const res: QueryResult = await client.query(query);
        return res.rows;
    } catch (error) {
        console.error(`Error executing query: ${error}`);
        throw error;
    } finally {
        await client.end();
    }
}

/**
 * Execute a non-query SQL statement (INSERT, UPDATE, DELETE)
 * @param connectionString - Postgres connection string
 * @param statement - SQL statement to execute
 * @param params - Parameters for the statement
 * @returns Number of affected rows
 */
export async function executeNonQuery(connectionString: string, statement: string, params: any[] = []): Promise<number> {
    const client = new Client({ connectionString });
    try {
        await client.connect();
        const res: QueryResult = await client.query(statement, params);
        return res.rowCount || 0;
    } catch (error) {
        console.error(`Error executing non-query: ${error}`);
        throw error;
    } finally {
        await client.end();
    }
}

/**
 * Execute a query and return the first column of the first row
 * @param connectionString - Postgres connection string
 * @param query - SQL query to execute
 * @param params - Parameters for the query
 * @returns The value of the first column of the first row, or null
 */
export async function executeScalar(connectionString: string, query: string, params: any[] = []): Promise<any> {
    const client = new Client({ connectionString });
    try {
        await client.connect();
        const res: QueryResult = await client.query(query, params);
        if (res.rows.length > 0) {
            return Object.values(res.rows[0])[0];
        }
        return null;
    } catch (error) {
        console.error(`Error executing scalar: ${error}`);
        throw error;
    } finally {
        await client.end();
    }
}

/**
 * Get a list of all tables in the public schema
 * @param connectionString - Postgres connection string
 * @returns List of table names
 */
export async function getTableNames(connectionString: string): Promise<string[]> {
    const query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'";
    const rows = await queryDatabase(connectionString, query);
    return rows.map(row => row.table_name);
}

/**
 * Check if a table exists in the public schema
 * @param connectionString - Postgres connection string
 * @param tableName - Name of the table to check
 * @returns True if table exists, False otherwise
 */
export async function tableExists(connectionString: string, tableName: string): Promise<boolean> {
    const query = "SELECT EXISTS (SELECT FROM information_schema.tables WHERE table_schema = 'public' AND table_name = $1)";
    return await executeScalar(connectionString, query, [tableName]);
}

/**
 * Get the row count of a table or query
 * @param connectionString - Postgres connection string
 * @param tableOrQuery - Name of the table or a SQL SELECT query
 * @returns Number of rows
 */
export async function getRowCount(connectionString: string, tableOrQuery: string): Promise<number> {
    let query: string;
    if (tableOrQuery.trim().toUpperCase().startsWith("SELECT")) {
        query = `SELECT COUNT(1) FROM (${tableOrQuery}) AS subquery`;
    } else {
        query = `SELECT COUNT(1) FROM ${tableOrQuery}`;
    }

    const result = await executeScalar(connectionString, query);
    return parseInt(result, 10);
}
