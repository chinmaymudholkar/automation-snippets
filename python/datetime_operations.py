"""
Date and time utility functions for test automation
"""

import time
from datetime import datetime


def get_today_date(date_format: str = "%Y-%m-%d") -> str:
    """
    Get today's date in the specified format
    
    Args:
        date_format: Date format pattern (e.g., "%Y-%m-%d", "%m/%d/%Y", "%d-%b-%Y")
        
    Returns:
        Formatted date string
    """
    return datetime.now().strftime(date_format)


def get_current_timestamp(timestamp_format: str = "%Y-%m-%d %H:%M:%S") -> str:
    """
    Get current timestamp in the specified format
    
    Args:
        timestamp_format: Timestamp format pattern (e.g., "%Y-%m-%d %H:%M:%S", "%Y%m%d_%H%M%S")
        
    Returns:
        Formatted timestamp string
    """
    return datetime.now().strftime(timestamp_format)


def wait_for(seconds: float) -> None:
    """
    Wait for specified seconds
    
    Args:
        seconds: Time to wait in seconds
    """
    time.sleep(seconds)


def wait_for_duration(duration: str) -> None:
    """
    Wait for a duration specified in a human-readable format
    Supports: d (days), h (hours), m (minutes), s (seconds)
    Examples: "2d5h10m", "30m", "1h30m", "2d", "45s"
    
    Args:
        duration: Duration string (e.g., "2d5h10m")
    """
    total_seconds = _parse_duration(duration)
    time.sleep(total_seconds)


def _parse_duration(duration: str) -> float:
    """
    Parse a duration string into seconds
    
    Args:
        duration: Duration string (e.g., "2d5h10m30s")
        
    Returns:
        Total seconds
    """
    total_seconds = 0.0
    number_buffer = ""
    
    for char in duration:
        if char.isdigit():
            number_buffer += char
        else:
            if number_buffer:
                value = int(number_buffer)
                
                char_lower = char.lower()
                if char_lower == 'd':
                    total_seconds += value * 24 * 60 * 60
                elif char_lower == 'h':
                    total_seconds += value * 60 * 60
                elif char_lower == 'm':
                    total_seconds += value * 60
                elif char_lower == 's':
                    total_seconds += value
                else:
                    raise ValueError(f"Invalid duration unit: {char}")
                
                number_buffer = ""
    
    return total_seconds
