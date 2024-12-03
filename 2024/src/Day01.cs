using System;
using System.Collections.Generic;

namespace src
{
    public class Day01
    {
        public static int distance(int x, int y)
        {
            return Math.Abs(x - y);
        }

        public static int distance(int[] x, int[] y)
        {
            return x.OrderBy(i => i).Zip(y.OrderBy(j => j), (a, b) => distance(a, b)).Sum();
        }

        public static int distance(string input)
        {
            var x = new List<int>();
            var y = new List<int>();

            var lines = input.Split("\n").Select(l => l.Trim());

            // System.Console.WriteLine("lines : " + lines);
            foreach (var line in lines) {
                string[] parts = line.Split("   ");
                x.Add(Int32.Parse(parts[0].Trim()));
                y.Add(Int32.Parse(parts[1].Trim()));
            }

            return distance(x.ToArray(), y.ToArray());
        }

        public static int similarity(int[] x, int[] y)
        {
            // Get the number of times each number appears in the second  list
            var yCounts = y.CountBy(i => i).ToDictionary();

            // PrintDictionary(yCounts, "yCounts");

            var similarityScore = x.Select(i => yCounts.ContainsKey(i) ? yCounts[i] * i : 0).Sum();

            return similarityScore;
        }

        public static int similarity(string input)
        {
            var x = new List<int>();
            var y = new List<int>();

            var lines = input.Split("\n").Select(l => l.Trim());

            foreach (var line in lines) {
                string[] parts = line.Split("   ");
                x.Add(Int32.Parse(parts[0].Trim()));
                y.Add(Int32.Parse(parts[1].Trim()));
            }

            return similarity(x.ToArray(), y.ToArray());
        }

        public static void PrintDictionary(Dictionary<int, int> dictionary, string dictionaryName) {
            foreach (var kvp in dictionary) {
                Console.WriteLine(dictionaryName + ": " + kvp.Key + " : " + kvp.Value);
            }
        }
    }
}
