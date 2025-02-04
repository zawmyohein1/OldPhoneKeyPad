using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhoneKeyPad
{
    public static class OldPhonePad
    {
        public static string Convert(string input)
        {
            var keypad = new Dictionary<char, string>
            {
                {'2', "ABC"},
                {'3', "DEF"},
                {'4', "GHI"},
                {'5', "JKL"},
                {'6', "MNO"},
                {'7', "PQRS"},
                {'8', "TUV"},
                {'9', "WXYZ"}
            };

            string processedInput = input.Split('#')[0];
            List<char> result = new List<char>();
            string currentGroup = "";

            foreach (char c in processedInput)
            {
                if (c == ' ')
                {
                    ProcessCurrentGroup(ref currentGroup, result, keypad);
                }
                else if (c == '*')
                {
                    ProcessCurrentGroup(ref currentGroup, result, keypad);
                    HandleBackspace(result);
                }
                else
                {
                    HandleDigit(c, ref currentGroup, result, keypad);
                }
            }

            ProcessCurrentGroup(ref currentGroup, result, keypad);

            return new string(result.ToArray());
        }

        private static void ProcessCurrentGroup(ref string currentGroup, List<char> result, Dictionary<char, string> keypad)
        {
            if (currentGroup.Length == 0) return;

            char digit = currentGroup[0];
            int count = currentGroup.Length;
            char ch = GetChar(digit, count, keypad);
            result.Add(ch);
            currentGroup = "";
        }

        private static void HandleBackspace(List<char> result)
        {
            if (result.Count > 0)
            {
                result.RemoveAt(result.Count - 1);
            }
        }

        private static void HandleDigit(char c, ref string currentGroup, List<char> result, Dictionary<char, string> keypad)
        {
            if (currentGroup.Length == 0)
            {
                currentGroup = c.ToString();
            }
            else
            {
                if (currentGroup[0] == c)
                {
                    currentGroup += c;
                }
                else
                {
                    ProcessCurrentGroup(ref currentGroup, result, keypad);
                    currentGroup = c.ToString();
                }
            }
        }

        private static char GetChar(char digit, int count, Dictionary<char, string> keypad)
        {
            string letters = keypad[digit];
            int index = (count - 1) % letters.Length;
            return letters[index];
        }
    }
}
