"""
Directory and path utility functions for test automation
"""

import os
from pathlib import Path
from typing import List


def get_root_folder_name() -> str:
    """
    Get the root folder name of the project
    
    Returns:
        Root folder name
    """
    return os.path.basename(os.getcwd())


def get_root_folder_path() -> str:
    """
    Get the root folder path of the project
    
    Returns:
        Root folder absolute path
    """
    return os.getcwd()


def create_directory(directory_path: str) -> None:
    """
    Create a directory if it doesn't exist
    
    Args:
        directory_path: Path to the directory
    """
    Path(directory_path).mkdir(parents=True, exist_ok=True)


def directory_exists(directory_path: str) -> bool:
    """
    Check if a directory exists
    
    Args:
        directory_path: Path to the directory
        
    Returns:
        True if directory exists, False otherwise
    """
    return os.path.isdir(directory_path)


def get_files_in_directory(directory_path: str, pattern: str = "*") -> List[str]:
    """
    Get all files in a directory with optional pattern
    
    Args:
        directory_path: Path to the directory
        pattern: Glob pattern (e.g., "*.txt")
        
    Returns:
        List of file paths
    """
    path = Path(directory_path)
    return [str(file) for file in path.glob(pattern) if file.is_file()]


def join_paths(*paths: str) -> str:
    """
    Join multiple path segments into a single path
    
    Args:
        paths: Path segments to join
        
    Returns:
        Combined path string
    """
    return os.path.join(*paths)


def get_absolute_path(relative_path: str) -> str:
    """
    Convert a relative path to an absolute path
    
    Args:
        relative_path: Relative path
        
    Returns:
        Absolute path
    """
    return os.path.abspath(relative_path)


def get_parent_directory(file_path: str) -> str:
    """
    Get the parent directory of a file or directory
    
    Args:
        file_path: Path to the file or directory
        
    Returns:
        Parent directory path
    """
    return os.path.dirname(file_path)
