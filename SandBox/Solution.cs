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

    // Complete the timeInWords function below.
    private static readonly string[] m_Hours = {
        "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
        "eleven", "twelve"};

    private static readonly string[] m_Minutes = {
        "", "one", "two", "three", "four", "five", "six","seven", "eight", "nine", "ten",
        "eleven", "twelve", "thirteen", "fourteen", "fifteen",
        "sixteen", "seventeen", "eighteen", "nineteen", "twenty",
        "twenty one", "twenty two", "twenty three", "twenty four", "twenty five",
        "twenty six", "twenty seven", "twenty eight", "twenty nine" };

    static string TimeInWords(int h, int m)
    {
        if (m == 0)
        {
            return OClock(h);
        }

        if (m <= 30)
        {
            return PastHour(h, m);
        }

        return ToHour(h, m);
    }

    private static string OClock(int h)
    {
        return string.Concat(m_Hours[h], " o' clock");
    }

    private static string PastHour(int h, int m)
    {
        if (m == 1)
        {
            return string.Concat("one minute past ", m_Hours[h]);
        }
        if (m == 15)
        {
            return string.Concat("quarter past ", m_Hours[h]);
        }
        if (m == 30)
        {
            return string.Concat("half past ", m_Hours[h]);
        }
        return string.Concat(m_Minutes[m], " minutes past ", m_Hours[h]);
    }

    private static string ToHour(int h, int m)
    {
        h = h == 12 ? 1 : h + 1;
        m = 60 - m;

        if (m == 15)
        {
            return string.Concat("quarter to ", m_Hours[h]);
        }
        return string.Concat(m_Minutes[m], " minutes to ", m_Hours[h]);
    }

    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        string result = TimeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

