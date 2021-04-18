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
                    if (i.All(char.IsLower) && value.Count > 1)
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
                    if (value[i].All(char.IsUpper) && value.Count > 2)
                    {
                        mem.Add(value[i]);
                        if (mem.Count < 2)
                            continue;

                    }
                    if (value[i].All(char.IsUpper) && value.Count > 2)
                    {
                        NewState++;
                        rules.Add(alphabet[NewState].ToString(), mem[0] + value[i]);
                        rules.RemoveAt(item);
                        var result = String.Join("", value);
                        result = result.Replace(mem[0] + value[i], alphabet[NewState].ToString());
                        rules.InsertAt(item, rules[item].Key, result);
                        result = "";
                    }

                    mem.Clear();
                    if (rules[item].Value.Count() % 2 == 0)
                    {
                        break;
                    }
                }
                value.Clear();
            }
        }
        public void Del(ProductionRules rules)
        {
           
        }
        public void Display(ProductionRules rules)
        {
            foreach (var item in rules)
            {
                string x = string.Format("{0} -> {1} ", item.Key, item.Value);
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------------------- \n");
        }
    }
}
