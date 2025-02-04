How the Code Works

    Key Mapping Setup
        A dictionary (keyMapping) stores key-number-to-letters mapping.
        Example: '2' → "ABC", '7' → "PQRS", etc.

    Processing Input String
        The input is processed character by character.
        Everything after # is ignored.

    Handling Characters
        If it's a number (2-9), it groups repeated presses.
        If it's a space (' '), it confirms the last letter.
        If it's a '*' (backspace), it removes the last letter.

    Final Conversion
        The sequence of presses determines the selected letter.
        Example:
            "222" → "C" (3rd letter on 2).
            "7777" → "S" (4th letter on 7).