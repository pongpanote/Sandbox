using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Solution
{
    static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        var scoreRank = scores.Distinct().ToArray();
        var scoreRankReversed = scoreRank.Reverse().ToArray();

        return alice.Select(score => GetScorePosition(score, scoreRankReversed)).ToArray();
    }

    static int GetScorePosition(int score, int[] scoreRankReversed)
    {
        var rank = Array.BinarySearch(scoreRankReversed, score);
        if (rank < 0)
        {
            rank = ~rank;
            if (rank == 0)
            {
                return scoreRankReversed.Length + 1;
            }

            if (rank == scoreRankReversed.Length)
            {
                return 1;
            }
        }

        if (score == scoreRankReversed[rank])
        {
            return scoreRankReversed.Length - rank;
        }

        return scoreRankReversed.Length - rank + 1;
    }


    static int twoCharaters(string s)
    {
        if (s.Length < 2)
        {
            return 0;
        }

        var tuplesHashSet = GetPermutation(new HashSet<char>(s.ToCharArray()));

        var trimming = Trimming(s, tuplesHashSet);

        var distinctAlternate = DistinctlyAlternate(trimming);

        return distinctAlternate.Any() ? distinctAlternate.First().Length : 0;
    }

    private static IOrderedEnumerable<string> DistinctlyAlternate(HashSet<IEnumerable<char>> trimming)
    {
        var result = new HashSet<string>();
        foreach (var item in trimming)
        {
            var charArray = item.ToArray();
            if (charArray.Length == 1)
            {
                result.Add(string.Concat(charArray));
                continue;
            }

            var distinct = true;
            for (var i = 0; i < charArray.Length - 1; i++)
            {
                if (charArray[i] == charArray[i + 1])
                {
                    distinct = false;
                    break;
                }
            }

            if (distinct)
            {
                result.Add(string.Concat(charArray));
            }
        }

        return result.ToList().OrderByDescending(str => str.Length);
    }

    private static HashSet<IEnumerable<char>> Trimming(string s, HashSet<Tuple<char, char>> tuplesHashSet)
    {
        var trimming = new HashSet<IEnumerable<char>>();

        foreach (var tuple in tuplesHashSet)
        {
            trimming.Add(s.ToCharArray().Where(ch => ch == tuple.Item1 || ch == tuple.Item2));
        }

        return trimming;
    }

    private static HashSet<Tuple<char, char>> GetPermutation(HashSet<char> charHashSet)
    {
        var permutation = new HashSet<Tuple<char, char>>();

        while (charHashSet.Count >= 2)
        {
            var ch = charHashSet.First();
            charHashSet.Remove(ch);
            foreach (var c in charHashSet)
            {
                permutation.Add(new Tuple<char, char>(ch, c));
            }
        }

        return permutation;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        var result1 = climbingLeaderboard(new[]
        {
            100, 100, 50, 40, 40, 20, 10
        }, new[]
        {
            5, 25, 50, 120
        });

        Console.WriteLine(string.Join("\n", result1));


        var l = Convert.ToInt32(Console.ReadLine());

        var s = Console.ReadLine();

        var result = twoCharaters(s);

        Console.ReadLine();
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
