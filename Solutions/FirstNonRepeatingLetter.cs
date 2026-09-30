// https://www.codewars.com/kata/52bc74d4ac05d0945d00054e
// 5 kyu
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

internal class FirstNonRepeatingLetter
{

    public static string Solve(string s)
    {
        /*
        for each c
            if not c occurs elsewhere in string in lowercase or uppercase
                return c
        */
        for (int i = 0; i < s.Length; i++)
        {
            if (!LetterIsInRemainderOfString(s, i) && !LetterIsInBeginningOfString(s, i))
            {
                return s[i].ToString();
            }
        }

        return string.Empty;

        static bool LetterIsInBeginningOfString(string s, int i)
        => i != 0 && (CharIsInBeginningOfString(s, i, s.ToLower()[i]) || CharIsInBeginningOfString(s, i, s.ToUpper()[i]));

        static bool LetterIsInRemainderOfString(string s, int i)
        => CharIsInRemainderOfString(s, i, s.ToLower()[i]) || CharIsInRemainderOfString(s, i, s.ToUpper()[i]);

        static bool CharIsInBeginningOfString(string s, int i, char c)
        => s[..i].Contains(c);

        static bool CharIsInRemainderOfString(string s, int i, char c)
        => s[(i + 1)..].Contains(c);
    }
}