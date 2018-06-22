using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Numerics;

class Solution1
{

    // Complete the biggerIsGreater function below.
    private static string BiggerIsGreater(string w)
    {
        var charValue = w.ToCharArray().Select(ch => Convert.ToInt32(ch)).ToArray();

        for (var i = charValue.Length - 1; i >= 0; i--)
        {
            int[] reOrdered;
            if (i > 0)
            {
                reOrdered = ReorderFromIndex(charValue, i, OrderByDescending);
                if (!IsGreater(reOrdered, charValue))
                {
                    continue;
                }
            }
            else
            {
                reOrdered = SwapTheNextGreaterChar(charValue);
            }

            var result = ReorderFromIndex(reOrdered, i + 1, OrderByAscending);

            if (IsGreater(result, charValue))
            {
                return ToString(result);
            }
        }
        
        return "no answer";
    }

    private static int[] SwapTheNextGreaterChar(int[] charValue)
    {
        var firstChar = charValue[0];

        var charValueCopy = charValue.ToArray();

        for (var i = charValue.Length - 1; i > 0; i--)
        {
            if (charValue[i] <= firstChar)
            {
                continue;
            }

            charValueCopy[0] = charValueCopy[i];
            charValueCopy[i] = firstChar;

            return charValueCopy; 
        }

        return charValueCopy;
    }


    private static string ToString(int[] charArray)
    {
        var strArray = charArray.Select(ch => Convert.ToChar(ch));

        return string.Concat(strArray);
    }

    private static bool IsGreater(int[] reOrdered, int[] charValue)
    {
        return reOrdered.Where((t, i) => t > charValue[i]).Any();
    }

    private static int[] ReorderFromIndex(int[] charValue, int fromThisIndex, Func<IEnumerable<int>, IEnumerable<int>> orderFunction)
    {
        var left = charValue.Take(charValue.Length - (charValue.Length - fromThisIndex)).ToList();
        var right = charValue.Skip(fromThisIndex);

        right = orderFunction(right);
        left.AddRange(right);

        return left.ToArray();
    }

    private static IEnumerable<int> OrderByDescending(IEnumerable<int> right)
    {
        return right.OrderByDescending(ch => ch);
    }

    private static IEnumerable<int> OrderByAscending(IEnumerable<int> right)
    {
        return right.OrderBy(ch => ch);
    }


    public static void SMain(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        var t = Convert.ToInt32(Console.ReadLine());

        for (var tItr = 0; tItr < t; tItr++)
        {
            var w = Console.ReadLine();

            var result = BiggerIsGreater(w);

            Console.WriteLine(result);

            //textWriter.WriteLine(result);
        }

        Console.ReadLine();

        //textWriter.Flush();
        //textWriter.Close();


        //5
        //ab      ba
        //bb
        //hefg    hegf
        //dhck    dhkc
        //dkhc    hcdk

    }
}

