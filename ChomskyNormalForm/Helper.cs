using System;
using System.Collections.Generic;
using System.Text;

namespace ChomskyNormalForm
{
    public static class  Helper
    {
        public static void Display(ProductionRules rules)
        {
            foreach (var item in rules)
            {
                string x = string.Format("{0} -> {1} ", item.Key, item.Value);
                Console.WriteLine(x);
            }
            Console.WriteLine("----------------------------------------------- \n");
        }
        public static void GetDistinct(ProductionRules rules)
        {
            for (int i = 0; i < rules.Count; i++)
            {
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (rules[z].Key == rules[i].Key && rules[z].Value == rules[i].Value)
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (duplicate)
                {
                    rules.RemoveAt(i);
                }
            }
        }

        public static bool IsUpper(string value)
        {
            // Consider string to be uppercase if it has no lowercase letters.
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsLower(string value)
        {
            // Consider string to be lowercase if it has no uppercase letters.
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        public static IEnumerable<int> AllIndexesOf(string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
            }
        }
    }
}
