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
class GhostLegs
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        List<string> diagram = new List<string>();
        for (int j = 0; j < H; j++)
        {
            diagram.Add(Console.ReadLine());
        }
        for (int i = 0; i < W; i += 3)
        {
            string firstline = diagram[0];
            char T = firstline[i];
            char B = ' ';
            int currentRow = i;
            for (int j = 0; j < H - 1; j++)
            {
                string line = diagram[j + 1];
                if (currentRow < W - 1 && line[currentRow + 1] == '-')
                {
                    currentRow += 3;
                }
                else if (currentRow != 0 && line[currentRow - 1] == '-')
                {
                    currentRow -= 3;
                }
                if (line[0] != '|')
                {
                    B = line[currentRow];
                }
            }

            Console.WriteLine(T + B.ToString());
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}