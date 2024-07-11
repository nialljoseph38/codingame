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

        string MESSAGE = Console.ReadLine();
        string binary = "";
        for (int i = 0; i < MESSAGE.Length; i++)
        {
            char letter = MESSAGE[i];
            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int dec = letter;
            binary += Convert.ToString(dec, 2).PadLeft(7, '0');
        }
        string unary = "";
        int index = 0;
        while (true)
        {
            if (binary[index] == '1')
            {
                unary += "0 ";
                while (binary[index] == '1')
                {
                    unary += "0";
                    index++;
                    if (index == binary.Length)
                    {
                        break;
                    }
                }
                unary += " ";

            }
            else
            {
                unary += "00 ";
                while (binary[index] == '0')
                {
                    unary += "0";
                    index++;
                    if (index == binary.Length)
                    {
                        break;
                    }
                }
                unary += " ";
            }
            if (index == binary.Length)
            {
                break;
            }
        }
        unary = unary[0..^1];


        Console.WriteLine(unary);
    }
}
