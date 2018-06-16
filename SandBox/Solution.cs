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
    static int[] getOneBits(int n)
    {
        var binaryString = Convert.ToString(n, 2);
        var sumOfOne = binaryString.Count(x=>x=='1');
        var result = new List<int>();

        result.Add(sumOfOne);

        for (var i = 0; i < binaryString.Length; i++)
        {
            if (binaryString[i] == '1')
            {
                result.Add(i + 1);
            }
        }

        return result.ToArray();
    }

}

