using DataStructuresUtils;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;

namespace RegExTests
{
    class Program
    {
        //public static int GetQuarter(this DateTime date)
        //{
        //    return (date.Month + 2) / 3;
        //}

        static void Main(string[] args)
        {
            {
                long v1 = 30;
                long max = 51;

                var r = (v1 * 100) / (float)max;

                var dict = new Dictionary<(string, string), List<string>>();

                var k1 = ("N1", "Z1");
                var k2 = ("N2", "Z2");
                var k3 = ("N3", "Z3");

                AddOrUpdate(k1, "1");
                AddOrUpdate(k2, "2");
                AddOrUpdate(k3, "3");
                AddOrUpdate(k1, "11");
                AddOrUpdate(k1, "111");

                foreach(var kv in dict)
                {
                    Console.WriteLine($"Key: {kv.Key}");
                    foreach(var code in kv.Value)
                    {
                        Console.WriteLine($"\t - {code}");
                    }
                }

                void AddOrUpdate((string name, string zipCode) key, string code)
                {
                    if (dict.ContainsKey(key))
                    {
                        dict[key].Add(code);
                    }
                    else
                    {
                        var codes = new List<string>() { code };
                        dict.Add(key, codes);
                    }
                }
            }

            {
                var reg = new Regex("the");
                string str1 = "the quick brown fox jumped over the lazy dog";
                var matches = reg.Matches(str1);

                for (var m = 0; m < matches.Count; m++)
                {
                    var matchSet = matches[m];
                    if (matchSet.Success)
                    {
                        var captures = matchSet.Captures;
                        for (int cap = 0; cap < captures.Count; cap++)
                        {
                            Console.WriteLine(captures[cap].Value);
                        }
                    }
                }
            }

            {
                var input = "08/14/57 46 02/25/59 45 06/05/85 18 03/12/88 16 09/09/90 13";
                using (Timing.Create("First"))
                {
                    var matches = Regex.Matches(input, @"\s\d{2}\s");

                    for (var i = 0; i < matches.Count; i++)
                    {
                        var v = matches[i].Value;
                        Console.WriteLine(v);
                    }
                }
            }

            {
                using (Timing.Create("Alternation |"))
                {
                    var input = "01-9999999 020-333333 777-88-9999";

                    var pattern = @"\b(\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b";

                    foreach (Match match in Regex.Matches(input, pattern))
                    {
                        Console.WriteLine($"{match.Value} at position {match.Index}");
                    }
                }
            }

            {
                using (Timing.Create("positive lookahead assertion"))
                {
                    var input = " lions lion tigers tiger bears,bear";
                    var pattern = @"\w+(?=\s)";

                    foreach(Match match in Regex.Matches(input, pattern))
                    {
                        Console.WriteLine(match.Value);
                    }
                }
            }


            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
