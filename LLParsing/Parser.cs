using ChomskyNormalForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLParsing
{
    public static class Parser
    {
        public static List<string> GetFirst(ProductionRules rules)
        {
            List<string> value = new List<string>();
            List<string> first = new List<string>();
            for (int item = 0; item < rules.Count; ++item)
            {
                value.AddRange(rules[item].Value.Select(d => d.ToString()));
                if (Helper.IsLower(value[0]))
                {
                    first.Add(value[0]);
                }
                else if (Helper.IsUpper(value[0]))
                {
                    for (int j = 0; j < rules.Count; ++j)
                    {
                        if (rules[j].Key.Contains(rules[item].Key) && rules[j].Value.StartsWith(rules[item].Key))
                        {
                        }
                    }
                }
            }
            return first;
        }
    }
}
