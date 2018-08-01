using System;
using System.Linq;

namespace SandBox
{
    public class Program1
    {
        private static void PlusMinus(int[] arr)
        {
            var sorted = arr.OrderByDescending(x => x);
            var max = sorted.FirstOrDefault();
            var result = sorted.Count(x => x == max);
        }

        private const string QUERY_TITLE = "/Title/crid:~~2F~~2Ftitle~~2F1/props/ExplanatoryText?Language={0}";
        private static void Main(string[] args)
        {

            var query = string.Format(QUERY_TITLE, "en");
            Console.WriteLine(query);

            //int n = Convert.ToInt32(Console.ReadLine());

            //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            //var arr = new[] {1, 3, 1, 3, 3, 2};
            //    PlusMinus(arr);
            }
        }
    }
