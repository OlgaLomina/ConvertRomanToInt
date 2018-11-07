using System;
using System.Collections.Generic;
/*
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.

Example 1:

Input: "III"
Output: 3
Example 2:

Input: "IV"
Output: 4
Example 3:

Input: "IX"
Output: 9
Example 4:

Input: "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.
Example 5:

Input: "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 * 
 * */
namespace Num1
{

    public class Solution
    {
        public static int RomanToInt0(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            Dictionary<char, char> pair = new Dictionary<char, char>();
            pair.Add('V', 'I');
            pair.Add('X', 'I');
            pair.Add('L', 'X');
            pair.Add('C', 'X');
            pair.Add('D', 'C');
            pair.Add('M', 'C');

            int len = s.Length;

            int res = 0, temp = 0, temp_prev = 0;
            char prev = (char)0, s_pair = (char)0;
            for (int i = 0; i < len; i++)
            {
                if (dict.TryGetValue(s[i], out temp))
                    res = res + temp;

                //try to find pair and
                if (pair.TryGetValue(s[i], out s_pair))
                    if (s_pair == prev)
                        if (dict.TryGetValue(s_pair, out temp_prev))
                            res = res - temp_prev * 2;

                prev = s[i];
            }

            return res;
        }

        public static int RomanToInt(string s)
        {
            int len = s.Length;

            int res = 0, temp = 0, temp_prev = 0;
            char prev = (char)0, s_pair = (char)0;

            for (int i = 0; i < len; i++)
            {
                temp = IsValue(s[i]);
                res = res + temp;

                //try to find pair
                s_pair = FindPair(s[i]);

                if (s_pair == prev)
                {
                    temp_prev = IsValue(s_pair);
                    res = res - temp_prev * 2;
                }

                prev = s[i];
            }

            return res;
        }

        public static int IsValue(char ch)
        {
            int val = 0;
            switch (ch)
            {
                case 'I':
                    val = 1;
                    break;
                case 'V':
                    val = 5;
                    break;
                case 'X':
                    val = 10;
                    break;
                case 'L':
                    val = 50;
                    break;
                case 'C':
                    val = 100;
                    break;
                case 'D':
                    val = 500;
                    break;
                case 'M':
                    val = 1000;
                    break;
                default:
                    break;
            }
            return val;
        }

        public static char FindPair(char c)
        {
            char pair = (char)0;
            switch (c)
            {
                    case 'V':
                        pair = 'I';
                        break;
                    case 'X':
                        pair = 'I';
                        break;
                    case 'L':
                        pair = 'X';
                        break;
                    case 'C':
                        pair = 'X';
                        break;
                    case 'D':
                        pair = 'C';
                        break;
                    case 'M':
                        pair = 'C';
                        break;
                    default:
                        break;
            }
            return pair;
        }

        public static void Main()
        {
            string str = "MCMXCIV";
            int i = RomanToInt(str);
            Console.WriteLine(i);
        }
    }
}