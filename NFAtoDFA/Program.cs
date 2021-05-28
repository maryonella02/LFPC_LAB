using System;

using System.Collections.Generic;
using System.IO;

namespace NFAtoDFA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num_of_states = 3;
            char[] states_ar = new char[] { 'A', 'B', 'C' };
            Dictionary<char, int> states = new Dictionary<char, int>();
            states['A'] = 0;
            states['B'] = 1;
            states['C'] = 2;

            char initial_state = 'A';
            Dictionary<char, int> final_states = new Dictionary<char, int>();
            final_states['C'] = 1;

            int num_of_symbols = 2;
            char[] alphabet = new char[] { 'a', 'b' };

            LinkedList<string> q = new LinkedList<string>();
            Dictionary<string, int> map = new Dictionary<string, int>();
            q.AddLast(initial_state + "");
            map[initial_state + ""] = 1;

            string[][] NFA_table = Array.RectangularStringArray(num_of_states, num_of_symbols);

            Console.Write("\n\t");
            for (int al = 0; al < num_of_symbols; al++)
            {
                Console.Write(alphabet[al] + "\t");
            }
            Console.WriteLine();

            string[,] NFA_table = new string[3, 2] { { "AB", "-" }, { "C", "B" },
                                        { "A", "C" } };
            Console.WriteLine("\nEquivalent DFA Table: ");
            Array.Convert();

           
        }
    }

}

