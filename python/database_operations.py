import sqlite3
import pandas as pd

def query_database(db_path: str, query: str) -> pd.DataFrame:
    """
    Run a query on an sqlite database and return the results in a dataframe
    
    Args:
        db_path: Path to the SQLite database file
        query: SQL query to execute
        
    Returns:
        pandas.DataFrame containing the query results
    """
    with sqlite3.connect(db_path) as conn:
        return pd.read_sql_query(query, conn)


def execute_non_query_statement(db_path: str, statement: str, params: tuple = ()) -> int:
    """
    Execute a non-query SQL statement (INSERT, UPDATE, DELETE)
    
    Args:
        db_path: Path to the SQLite database file
        statement: SQL statement to execute
        params: Parameters for the statement
        
    Returns:
        Number of affected rows
    """
    with sqlite3.connect(db_path) as conn:
        cursor = conn.cursor()
        cursor.execute(statement, params)
        conn.commit()
        return cursor.rowcount


def execute_scalar(db_path: str, query: str, params: tuple = ()) -> any:
    """
    Execute a query and return the first column of the first row
    
    Args:
        db_path: Path to the SQLite database file
        query: SQL query to execute
        params: Parameters for the query
        
    Returns:
        The value of the first column of the first row, or None
    """
    with sqlite3.connect(db_path) as conn:
        cursor = conn.cursor()
        cursor.execute(query, params)
        result = cursor.fetchone()
        return result[0] if result else None


def get_table_names(db_path: str) -> list[str]:
    """
    Get a list of all tables in the database
    
    Args:
        db_path: Path to the SQLite database file
        
    Returns:
        List of table names
    """
    query = "SELECT name FROM sqlite_master WHERE type='table'"
    with sqlite3.connect(db_path) as conn:
        cursor = conn.cursor()
        cursor.execute(query)
        return [row[0] for row in cursor.fetchall()]


def table_exists(db_path: str, table_name: str) -> bool:
    """
    Check if a table exists in the database
    
    Args:
        db_path: Path to the SQLite database file
        table_name: Name of the table to check
        
    Returns:
        True if table exists, False otherwise
    """
    return table_name in get_table_names(db_path)


def get_row_count(db_path: str, table_or_query: str) -> int:
    """
    Get the row count of a table or query
    
    Args:
        db_path: Path to the SQLite database file
        table_or_query: Name of the table or a SQL SELECT query
        
    Returns:
        Number of rows
    """
    if table_or_query.strip().upper().startswith("SELECT"):
        query = f"SELECT COUNT(1) FROM ({table_or_query})"
    else:
        query = f"SELECT COUNT(1) FROM {table_or_query}"
    
    return execute_scalar(db_path, query)