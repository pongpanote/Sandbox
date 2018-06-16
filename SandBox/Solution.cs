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

class Solution
{
    // Complete the miniMaxSum function below.
    static void miniMaxSum(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            var y = arr.SkipWhile(x => x == arr.ElementAt(i));
            

        }

        //Console.WriteLine($"{min} {max}");
        //1659655705 2484892405
    }

    public static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
        miniMaxSum(arr);
        Console.ReadLine();
    }
}

