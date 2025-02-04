using System.Collections.Generic;

namespace OldPhoneKeyPad
{
    public static class OldPhonePad
    {
        public static string Decode(string input)
        {
            // Mapping of number keys to corresponding letters
            var keyMapping = new Dictionary<char, string>
            {
                { '2', "ABC" }, { '3', "DEF" },
                { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
                { '7', "PQRS" },{ '8', "TUV" }, { '9', "WXYZ" }
            };

            // Ignore everything after '#' (used as a termination character)
            string sanitizedInput = input.Split('#')[0];
            var outputText = new List<char>();
            string keySequence = "";

            foreach (char key in sanitizedInput)
            {
                switch (key)
                {
                    case ' ':
                        ProcessSequence(ref keySequence, outputText, keyMapping);
                        break;

                    case '*':
                        ProcessSequence(ref keySequence, outputText, keyMapping);
                        RemoveLastCharacter(outputText);
                        break;

                    default:
                        ProcessKeyPress(key, ref keySequence, outputText, keyMapping);
                        break;
                }
            }

            // Process any remaining key sequences
            ProcessSequence(ref keySequence, outputText, keyMapping);

            return new string(outputText.ToArray());
        }

        private static void ProcessSequence(ref string keySequence, List<char> outputText, Dictionary<char, string> keyMapping)
        {
            if (string.IsNullOrEmpty(keySequence)) return;

            char key = keySequence[0];
            int pressCount = keySequence.Length;
            outputText.Add(GetCharacterFromKey(key, pressCount, keyMapping));
            keySequence = "";
        }

        private static void RemoveLastCharacter(List<char> outputText)
        {
            if (outputText.Count > 0)
            {
                outputText.RemoveAt(outputText.Count - 1);
            }
        }

        private static void ProcessKeyPress(char key, ref string keySequence, List<char> outputText, Dictionary<char, string> keyMapping)
        {
            if (keySequence.Length > 0 && keySequence[0] != key)
            {
                ProcessSequence(ref keySequence, outputText, keyMapping);
            }
            keySequence += key;
        }

        private static char GetCharacterFromKey(char key, int pressCount, Dictionary<char, string> keyMapping)
        {
            if (!keyMapping.ContainsKey(key)) return '?'; // Handle unexpected input gracefully
            string letters = keyMapping[key];
            return letters[(pressCount - 1) % letters.Length];
        }
    }
}
