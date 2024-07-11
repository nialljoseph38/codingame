using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
        int minDist = -1;
        for (int i = 0; i < N; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));

        }
        list.Sort();
        for (int j = 0; j < N - 1; j++)
        {
            if ((list[j + 1] - list[j]) < minDist | minDist == -1)
            {
                minDist = (list[j + 1] - list[j]);
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(minDist);
    }
}