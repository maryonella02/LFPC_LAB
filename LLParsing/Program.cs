﻿using ChomskyNormalForm;
using System;
using System.Collections.Generic;
using System.IO;

namespace LLParsing
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader reader = File.OpenText(@"C:\Users\Marinela\source\repos\LFPC LAB\LLParsing\rules.txt");
            string line;
            var productions = new ProductionRules();
            while ((line = reader.ReadLine()) != null)
            {
                string[] rule = line.Split("->");
                productions.Add(rule[0], rule[1]);
            }

            Console.WriteLine("Initial form of the grammar:");
            Helper.Display(productions);

            Console.WriteLine("Eliminate left recursion:");
            productions.RemoveLeftRecursion(productions);
            Helper.Display(productions);

            Console.WriteLine("Obtain FIRST:");
            List<KeyValuePair<string, string>> first = Parser.GetFirst(productions);
            Helper.Display(first);

            Console.WriteLine("Obtain FOLLOW:");
            List<KeyValuePair<string, string>> follow = Parser.GetFollow(productions);
            Helper.Display(follow);

        }
    }
}
