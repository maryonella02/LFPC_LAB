﻿using System;
using System.Collections.Generic;
using System.IO;

namespace ChomskyNormalForm
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = File.OpenText(@"C:\Users\Marinela\source\repos\LFPC LAB\ChomskyNormalForm\rules1.txt");
            string line;
            var productions = new ProductionRules();
            while ((line = reader.ReadLine()) != null)
            {
                string[] rule = line.Split("->");
                productions.Add(rule[0], rule[1]);
            }

            Console.WriteLine("Initial form of the grammar:");
            Helper.Display(productions);

            Console.WriteLine("Eliminate the start symbol from right-hand sides:");
            productions.Start(productions);
            Helper.Display(productions);

            Console.WriteLine("Eliminate rules with nonsolitary terminals:");
            productions.Term(productions);
            Helper.Display(productions);

            Console.WriteLine("Eliminate ε-rules:");
            productions.Del(productions);
            Helper.Display(productions);

            int counter = 0;
            while (counter != productions.Count)
            {
                counter = productions.Count;
                Console.WriteLine("Eliminate right-hand sides with more than 2 nonterminals:");
                productions.Bin(productions);
                Helper.Display(productions);
            }

            Console.WriteLine("Eliminate unit rules:");
            productions.Unit(productions);
            Helper.Display(productions);

            Console.WriteLine("Eliminate unit rules:");
            productions.Unit(productions);
            Helper.Display(productions);
        }
    }
}
