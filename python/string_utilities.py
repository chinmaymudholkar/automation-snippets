"""
String generation and manipulation utility functions for test automation
"""

import random
import string
import uuid


def generate_random_string(length: int = 10) -> str:
    """
    Generate a random string of specified length
    
    Args:
        length: Length of the random string
        
    Returns:
        Random alphanumeric string
    """
    characters = string.ascii_letters + string.digits
    return ''.join(random.choice(characters) for _ in range(length))


def generate_random_integer(length: int = 10) -> str:
    """
    Generate a random integer of specified length
    
    Args:
        length: Length of the random integer string
        
    Returns:
        Random integer string
    """
    return ''.join(random.choice(string.digits) for _ in range(length))


def generate_uuid() -> str:
    """
    Generate a unique identifier (UUID)
    
    Returns:
        UUID string
    """
    return str(uuid.uuid4())
