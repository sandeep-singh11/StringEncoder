using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Console.WriteLine("Please enter string to be evaluated");
            input = Console.ReadLine();
            
            string output = Encode(input);

        }

        public static string Encode(string Input)
        {
            string final = string.Empty;
            StringBuilder finaloutput = new StringBuilder();
            System.Text.StringBuilder result = new System.Text.StringBuilder(Input.Length);

            System.Collections.Generic.Stack<char> s = new System.Collections.Generic.Stack<char>();

            foreach (char c in Input)
            {
                //Checking the numbers and then push to the stack
                if (System.Char.IsNumber(c))
                {
                    s.Push(c);
                }
                else
                {
                    while (s.Count > 0)
                    {
                        result.Append(s.Pop());
                    }


                    result.Append(c);
                    string o = result.ToString();
                    
                    //below method is used to replace others as per given validations

                    final = (replaceOthers(o.ToCharArray()));

                }
            }
            finaloutput.Append(final);

            while (s.Count > 0)
            {
                finaloutput.Append(s.Pop());

            }

            //lower cases for the output string

            return (finaloutput.ToString().ToLower());
        }

        static String replaceOthers(char[] s)
        {

            Regex rgx = new Regex("[^A-Za-z0-9]");
            bool containsSpecialCharacter = rgx.IsMatch(s.ToString());

            // Start traversing the string 
            for (int i = 0; i < s.Length; i++)
            {

                if (!HasVowel(s[i]))
                {

                    if (s[i] == 'a')
                    {
                        s[i] = '1';
                    }
                    else if (s[i] == 'e')
                    {
                        s[i] = '2';
                    }
                    else if (s[i] == 'i')
                    {
                        s[i] = '3';
                    }
                    else if (s[i] == 'o')
                    {
                        s[i] = '4';
                    }
                    else if (s[i] == 'u')
                    {
                        s[i] = '5';
                    }
                    else if (s[i] == ' ')
                    {
                        s[i] = 'y';
                    }
                    else if (s[i] == 'y')
                    {
                        s[i] = ' ';
                    }
                    else if (s.Any(ch => !char.IsLetterOrDigit(s[i])))
                    {
                        s[i] = s[i];
                    }

                    else
                    {
                        if (System.Char.IsNumber(s[i]))
                        {
                            //dont do anything
                        }
                        else
                        {
                            s[i] = (char)(s[i] - 1);

                            if (HasVowel(s[i]))
                            {
                                s[i] = (char)(s[i] - 1);
                            }
                        }
                    }
                }

            }
            return String.Join("", s);
        }

        public static bool HasVowel(char ch)
        {
            if (ch != 'a' || ch != 'e' || ch != 'i' || ch != 'o' || ch != 'u' || ch != ' ' || ch != 'y')
            {
                return false;
            }
            return true;
        }

    }
}
