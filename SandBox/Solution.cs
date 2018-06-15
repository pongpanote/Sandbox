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

class Solution
{

    // Complete the staircase function below.
    private static void Staircase(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            Console.WriteLine(FillCharacter(' ', n - i) + FillCharacter('#', i));
        }
    }

    private static string FillCharacter(char ch, int no)
    {
        var str = string.Empty;
        while (no > 0)
        {
            str += ch;
            no--;
        }
        return str;
    }


    public static void Main(string[] args)
    {
        var n = Convert.ToInt32(Console.ReadLine());

        Staircase(n);
    }
}

