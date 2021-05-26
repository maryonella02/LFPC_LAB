using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChomskyNormalForm
{
    public class ProductionRules : List<KeyValuePair<string, string>>
    {
        int NewState = 5;
        char[] alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
        public void Add(string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Add(element);
        }
        public void InsertFirst(string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Insert(0, element);
        }
        public void InsertAt(int index, string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Insert(index, element);
        }
        public void Start(ProductionRules rules)
        {
            foreach (var item in rules)
            {
                if (item.Value.Contains('S'))
                {
                    rules.InsertFirst("S0", "S");
                    break;
                }
            }
        }
       
        public void Term(ProductionRules rules)
        {
            List<string> value = new List<string>();

            for (int item = 0; item < rules.Count; ++item)
            {
                value.AddRange(rules[item].Value.Select(d => d.ToString()));
                foreach (var i in value)
                {
                    if (Helper.IsLower(i) && value.Count > 1)
                    {
                        NewState++;
                        rules.Add(alphabet[NewState].ToString(), i);
                        rules.RemoveAt(item);
                        var result = String.Join("", value);
                        result = result.Replace(i, alphabet[NewState].ToString());
                        rules.InsertAt(item, rules[item].Key, result);
                        result = "";
                    }
                }
                value.Clear();
            }
            Helper.GetDistinct(rules);
        }
        public void Bin(ProductionRules rules)
        {
            List<string> mem = new List<string>();
            List<string> value = new List<string>();

            for (int item = 0; item < rules.Count; ++item)
            {
                value.AddRange(rules[item].Value.Select(d => d.ToString()));
                for (int i = 0; i < value.Count; ++i)
                {
                    if (Helper.IsUpper(value[i]) && value.Count > 2)
                    {
                        mem.Add(value[i]);
                        if (mem.Count < 2)
                            continue;

                    }
                    if (Helper.IsUpper(value[i]) && value.Count > 2)
                    {
                        var result = "";
                        bool processed = false;
                        for (int k = 0; k < rules.Count; ++k)
                        {
                            if (rules[k].Value.Contains(mem[0] + value[i]) && rules[k].Value.Length == 2)
                            {
                                string key = rules[k].Key.ToString();
                                rules.RemoveAt(item);
                                result = String.Join("", value);
                                result = result.Replace(mem[0] + value[i], key);
                                rules.InsertAt(item, rules[item].Key, result);
                                result = "";
                                processed = true;
                                break;
                            }
                        }
                        if (processed != true)
                        {
                            NewState++;
                            rules.Add(alphabet[NewState].ToString(), mem[0] + value[i]);
                            rules.RemoveAt(item);
                            result = String.Join("", value);
                            result = result.Replace(mem[0] + value[i], alphabet[NewState].ToString());
                            rules.InsertAt(item, rules[item].Key, result);
                            result = "";
                        }
                    }
                    mem.Clear();
                    if (rules[item].Value.Count() % 2 == 0)
                    {
                        break;
                    }
                }
                value.Clear();
            }
            Helper.GetDistinct(rules);
        }
        public void Del(ProductionRules rules)
        {
            List<string> value = new List<string>();
            for (int item = 0; item < rules.Count; ++item)
            {
                if (rules[item].Value.Contains('*'))
                {
                    for (int i = 0; i < rules.Count; ++i)
                    {
                        value.AddRange(rules[i].Value.Select(d => d.ToString()));
                        for (int j = 0; j < value.Count; ++j)
                        {
                            if (value[j].Contains(rules[item].Key) && rules[i].Value.Length > 1)
                            {
                                foreach (var index in Helper.AllIndexesOf(rules[i].Value, rules[item].Key))
                                {
                                    string rule = rules[i].Value.Remove(index, 1);
                                    rules.Add(rules[i].Key, rule);
                                }
                                break;
                            }
                            if (value[j].Contains(rules[item].Key) && rules[i].Value.Length == 1)
                            {
                                rules.Add(rules[i].Key, "*");
                            }
                        }
                        value.Clear();
                    }
                }
            }
            for (int k = 0; k < rules.Count; ++k)
            {
                if (rules[k].Value.Contains('*'))
                {
                    rules.RemoveAt(k);
                }
            }
            Helper.GetDistinct(rules);
        }
        public void Unit(ProductionRules rules)
        {
            List<string> value = new List<string>();

            for (int item = 0; item < rules.Count; ++item)
            {
                value.AddRange(rules[item].Value.Select(d => d.ToString()));
                for (int i = 0; i < value.Count; ++i)
                {
                    if (Helper.IsUpper(value[i]) && value.Count == 1)
                    {
                        string key = rules[item].Key;
                        rules.RemoveAt(item);
                        Console.WriteLine("For {1} -> {0}", value[i], key);
                        foreach (var rule in rules.FindAll(element => element.Key.StartsWith(value[i])))
                        {
                            rules.Add(key, rule.Value);
                        }
                    }
                    value.Clear();
                }
            }
            Helper.GetDistinct(rules);
        }
        public void RemoveLeftRecursion(ProductionRules rules)
        {
            List<string> value = new List<string>();
            for (int item = 0; item < rules.Count; ++item)
            {

                value.AddRange(rules[item].Value.Select(d => d.ToString()));

                if (value[0].Contains(rules[item].Key))
                {
                    for (int j = 0; j < rules.Count; ++j)
                    {
                        if (rules[j].Key.Contains(rules[item].Key) && Helper.IsLower(rules[j].Value))
                        {
                            NewState++;
                            string terminal = rules[j].Value.ToString();
                            string nonTerminal = rules[item].Key;
                            rules.RemoveAt(j);
                            rules.InsertAt(j, nonTerminal, terminal + alphabet[NewState].ToString());
                            break;
                        }
                    }
                    for (int j = 0; j < rules.Count; ++j)
                    {
                        if (rules[j].Key.Contains(rules[item].Key) && rules[j].Value.StartsWith(rules[item].Key))
                        {
                            string production = rules[j].Value.Substring(1);
                            rules.RemoveAt(j);
                            rules.InsertAt(j, alphabet[NewState].ToString(), production + alphabet[NewState].ToString());
                            rules.InsertAt(j + 1, alphabet[NewState].ToString(), "*");
                            break;
                        }
                    }
                }
                value.Clear();
            }
            Helper.GetDistinct(rules);
        }
    }
}

