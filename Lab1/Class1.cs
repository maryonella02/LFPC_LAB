using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Lab1
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>
                {
                    { "S", ["bA"] },
                    { "A", ["b", "aB", "bA"] },
                    { "B", ["bC", "aB",] },
                    { "C", ["cA"] }
                };

        List<string> basic = new List<string>;

        foreach(var key in new List<string>(data.Keys)){
            basic.Add(key);
        }


    public String FormWord(string letter, List<string> int_str)
    {
        string temp_str = "";
        foreach (var idx in Enumerable.Range(0, int_str.Length))
            {
            if (int_str[idx].Contains(letter))
            {
                try
                {
                    temp_str += data[letter][idx];

                }
                catch ()
                {
                    temp_str += data[letter][idx - 1];
                }
            }
            else
            {
                temp_str += int_str[idx];
            }
        }

        if (temp_str.Contains("S") || temp_str.Contains("D"))
        {
            foreach (var letter in temp_str)
            {
                if (letter.IsUpper){
                    return FormWord(letter, temp_str);
                }
            }
        }
        else
        {
            return temp_str;
        }
    }

    public string EliminateDuplicates(string test)
    {
        var temp_test = test[0];

        foreach (var char in test){
            if (char != temp_test[-1])
            {
                temp_test += char;
            }
        }

        return temp_test;
    }

    public void Evaluate(List<string> list)
    {
        var trying = Console.Readline("Write a word: ");
        if list.Contains(EliminateDuplicates(trying)){
            Console.WriteLine("Accepted");
        }
        else
        {
            Console.WriteLine("Rejected");
            Console.WriteLine("Available basic combinations ", list);
            var answer = Console.Readline("Would you like to retry?\nyes / no\n");
            if (answer == "yes")
            {
                return Evaluate(list);
            }
            else
            {
                Console.WriteLine("Ok");
            }
        }

    }
}

