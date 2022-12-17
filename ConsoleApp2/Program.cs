using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        //There is a large pile of socks that must be paired by color.
        //Given an array of integers representing the color of each sock, 
        //determine how many pairs of socks with matching colors there are.

        //n = 7
        //ar = [1,2,1,2,1,3,2]

        //There is one pair of colar 1 and one of color 2.  There are three odd socks left, one of each color.
        //The number of pairs is 2.

        static int getPairs(int[] ar)
        {
            var colorsCounts = new Dictionary<int, int>();

            for (int i = 0; i < ar.Length; i++)
            {
                if (colorsCounts.ContainsKey(ar[i]))
                    colorsCounts[ar[i]] = colorsCounts[ar[i]]+1;
                else
                    colorsCounts.Add(ar[i], 1);
            }

            int pairs = 0;
            foreach (var colorCount in colorsCounts)
                pairs += colorCount.Value / 2;

            return pairs;
        }


        static int getPairsLinq(int[] ar)
        {
            var pairs = ar.GroupBy(x => x)
                .Select(x => new { x.Key, Value = x.Count() })
                .Sum(p => p.Value / 2);

            return pairs;
        }


        static int getPairsHashSet(int[] ar)
        {
            var colors = new HashSet<int>();
            var pairs = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (colors.Contains(ar[i]))
                {
                    pairs++;
                    colors.Remove(ar[i]);
                }
                else
                {
                    colors.Add(ar[i]);
                }
            }

            return pairs;
        }



        static void Main(string[] args)
        {
            int[] ar = { 1, 2, 1, 2, 1, 3, 2 };

            Console.WriteLine(getPairs(ar));

            Console.WriteLine(getPairsLinq(ar));

            Console.WriteLine(getPairsHashSet(ar));

            Console.ReadKey();
        }
    }
}
