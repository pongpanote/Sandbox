using System;
using System.Linq;

public class Solution
{
    private static string BiggerIsGreater(string w)
    {
        var charValue = w.ToCharArray().Select(ch => Convert.ToInt32(ch)).ToArray();

        var i = charValue.Length - 1;
        while (i > 0 && charValue[i - 1] >= charValue[i])
        {
            i--;
        }

        if (i <= 0)
        {
            return "no answer";
        }

        var j = charValue.Length - 1;

        while (charValue[j] <= charValue[i - 1])
        {
            j--;
        }

        var temp = charValue[i - 1];
        charValue[i - 1] = charValue[j];
        charValue[j] = temp;

        j = charValue.Length - 1;

        while (i < j)
        {
            temp = charValue[i];
            charValue[i] = charValue[j];
            charValue[j] = temp;
            i++;
            j--;
        }

        return ToString(charValue);
    }

    private static string ToString(int[] charArray)
    {
        var strArray = charArray.Select(ch => Convert.ToChar(ch));

        return string.Concat(strArray);
    }

    public static void Mainx(string[] args)
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

        //textWriter.Flush();
        //textWriter.Close();
    }
}
