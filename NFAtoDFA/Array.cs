using System.Collections.Generic;

namespace NFAtoDFA
{
    internal static class Array
    {
        public static string[][] RectangularStringArray(int size1, int size2)
        {
            string[][] newArray = new string[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new string[size2];
            }
            return newArray;
        }
        public static void Convert()
        {
            string[][] DFA_table = Array.RectangularStringArray(1000, num_of_symbols);
            string[] final_states_DFA = new string[1000];
            int nfa_final_states = 0;
            Dictionary<char, int> new_states;
            for (int i = 0; q.Count > 0; i++)
            {
                string current_state = q.RemoveFirst();
                Console.Write(current_state + "|\t");
                for (int j = 0; j < num_of_symbols; j++)
                {
                    DFA_table[i][j] = "";
                    if (current_state.Length == 1 && !states.ContainsKey(current_state[0]))
                    {
                        DFA_table[i][j] = current_state;
                        if (!map.ContainsKey(DFA_table[i][j]))
                        {
                            q.AddLast(DFA_table[i][j]);
                            map[DFA_table[i][j]] = 1;
                        }
                        if (final_states.ContainsKey((DFA_table[i][j][0])))
                        {
                            final_states_DFA[nfa_final_states++] = DFA_table[i][j];
                        }
                        Console.Write(DFA_table[i][j] + "\t");
                        continue;
                    }
                    int new_final_state = 0;
                    new_states = new Dictionary<char, int>();
                    for (int k = 0; k < current_state.Length; k++)
                    {
                        if (!states.ContainsKey(current_state[k]))
                        {
                            continue;
                        }
                        if (final_states.ContainsKey(current_state[k]))
                        {
                            new_final_state = 1;
                        }
                        for (int ch = 0; ch < NFA_table[states[current_state[k]]][j].Length; ch++)
                        {
                            if (!new_states.ContainsKey(NFA_table[states[current_state[k]]][j][ch]) && states.ContainsKey(NFA_table[states[current_state[k]]][j][ch]))
                            {
                                DFA_table[i][j] += NFA_table[states[current_state[k]]][j][ch];
                                new_states[NFA_table[states[current_state[k]]][j][ch]] = 1;
                            }
                        }
                    }

                    if (!map.ContainsKey(DFA_table[i][j]))
                    {
                        q.AddLast(DFA_table[i][j]);
                        map[DFA_table[i][j]] = 1;
                    }
                    if (new_final_state == 1)
                    {
                        final_states_DFA[nfa_final_states++] = DFA_table[i][j];
                    }
                    Console.Write(DFA_table[i][j] + "\t");
                }
            }
        }
    }

}

