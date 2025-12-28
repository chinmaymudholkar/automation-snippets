"""
File I/O utility functions for test automation
"""

import os
import pandas as pd
from pandas import DataFrame
from typing import List


def read_text_file(file_path: str) -> str:
    """
    Read a text file and return its contents
    
    Args:
        file_path: Path to the text file
        
    Returns:
        File contents as a string
    """
    with open(file_path, 'r', encoding='utf-8') as file:
        return file.read()


def read_text_file_lines(file_path: str) -> List[str]:
    """
    Read a text file and return its contents as a list of lines
    
    Args:
        file_path: Path to the text file
        
    Returns:
        List of lines from the file
    """
    with open(file_path, 'r', encoding='utf-8') as file:
        return file.readlines()


def write_text_file(file_path: str, content: str) -> None:
    """
    Write content to a text file
    
    Args:
        file_path: Path to the text file
        content: Content to write
    """
    with open(file_path, 'w', encoding='utf-8') as file:
        file.write(content)


def append_to_text_file(file_path: str, content: str) -> None:
    """
    Append content to a text file
    
    Args:
        file_path: Path to the text file
        content: Content to append
    """
    with open(file_path, 'a', encoding='utf-8') as file:
        file.write(content)


def file_exists(file_path: str) -> bool:
    """
    Check if a file exists
    
    Args:
        file_path: Path to the file
        
    Returns:
        True if file exists, False otherwise
    """
    return os.path.isfile(file_path)


def delete_file(file_path: str) -> bool:
    """
    Delete a file if it exists
    
    Args:
        file_path: Path to the file
        
    Returns:
        True if file was deleted, False otherwise
    """
    if os.path.isfile(file_path):
        os.remove(file_path)
        return True
    return False


def get_file_size(file_path: str) -> int:
    """
    Get the size of a file in bytes
    
    Args:
        file_path: Path to the file
        
    Returns:
        File size in bytes
    """
    return os.path.getsize(file_path)


def get_file_extension(file_path: str) -> str:
    """
    Get file extension from file path
    
    Args:
        file_path: Path to the file
        
    Returns:
        File extension (without dot)
    """
    return os.path.splitext(file_path)[1].lstrip('.')


def get_file_name_without_extension(file_path: str) -> str:
    """
    Get file name without extension
    
    Args:
        file_path: Path to the file
        
    Returns:
        File name without extension
    """
    return os.path.splitext(os.path.basename(file_path))[0]


def load_csv_to_dataframe(file_path: str) -> DataFrame:
    """
    Load a CSV file into a pandas DataFrame
    
    Args:
        file_path: Path to the CSV file
        
    Returns:
        pandas DataFrame containing the CSV data
    """
    return pd.read_csv(file_path)
