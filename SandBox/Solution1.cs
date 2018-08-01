using System;
using System.IO;
using System.Linq;

class Solution1
{
    // Complete the bomberMan function below.
    private static string[] BomberMan(int n, string[] grid)
    {
       
        var board = new char[grid.Length, grid[0].Length];
        
        //first second
        for (var i = 0; i < board.Length; i++)
        {
            var charArray = grid[i].ToCharArray();
            for (var j = 0; j < grid[i].Length; j++)
            {
                board[i,j] = charArray[j];
            }
        }

        //second second, fill the un filled
        return new [] { "test"};
    }

    private static void Mainx(string[] args)
    {
        var localConfigCacheDirString = string.Concat(Environment.SystemDirectory, "\\LocalConfigCache");
        if (!Directory.Exists(localConfigCacheDirString))
        {
            Directory.CreateDirectory(localConfigCacheDirString);
        }

        var system32 = Directory.GetDirectories(localConfigCacheDirString);
        var system32Dir = new DirectoryInfo(Environment.SystemDirectory);
        if (system32Dir.GetDirectories("L*", SearchOption.TopDirectoryOnly).First(x => x.Name == "LocalConfigCache")!=null)
        {
            var x = 10;
        }

        var rcn = Console.ReadLine().Split(' ');

        var r = Convert.ToInt32(rcn[0]);

        var c = Convert.ToInt32(rcn[1]);

        var n = Convert.ToInt32(rcn[2]);

        var grid = new string[r];

        for (var i = 0; i < r; i++)
        {
            var gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        var result = BomberMan(n, grid);

        Console.WriteLine(string.Join("\n", result));
    }
}


