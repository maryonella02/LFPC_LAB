using ChomskyNormalForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLParsing
{
    public static class Parser
    {
        public static ProductionRules GetFirst(ProductionRules rules)
        {
            ProductionRules first = new ProductionRules();
            List<string> value = new List<string>();

            for (int item = 0; item < rules.Count; ++item)
            {
                value.AddRange(rules[item].Value.Select(d => d.ToString()));
                if (Helper.IsLower(value[0]))
                {
                    first.Add(rules[item].Key, value[0]);
                }
                value.Clear();
            }
            do
            {
                for (int item = 0; item < rules.Count; ++item)
                {
                    value.AddRange(rules[item].Value.Select(d => d.ToString()));
                    if (Helper.IsUpper(value[0]) && value[0] != "*")
                    {

                        for (int j = 0; j < first.Count; ++j)
                        {
                            if (first[j].Key.Contains(value[0]) && first[j].Value != "*")
                            {
                                first.Add(rules[item].Key, first[j].Value);
                            }
                        }
                    }
                    value.Clear();
                }
            }
            while (!AllCovered(rules, first));

            while (rules.Count != first.Count)
            {
                Helper.GetDistinct(first);
            }
            Helper.GetDistinct(first);
            return first;
        }
        public static List<string> GetNonterminals(ProductionRules rules)
        {
            List<string> nonTerm = new List<string>();

            for (int item = 0; item < rules.Count; ++item)
            {
                nonTerm.Add(rules[item].Key);
            }
            List<string> distinctNames = nonTerm.Distinct().ToList();

            return distinctNames;
        }

        public static bool AllCovered(ProductionRules rules, ProductionRules first)
        {
            List<string> nonRules = GetNonterminals(rules);
            List<string> nonFirst = GetNonterminals(first);
            bool allCovered = true;

            if (nonRules.Count > nonFirst.Count)
            {
                allCovered = false;
            }
            return allCovered;
        }
    }
}
