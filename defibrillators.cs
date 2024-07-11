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
        string LON = Console.ReadLine();
        string LAT = Console.ReadLine();
        double LONa = convertDegrees(LON);
        double LATa = convertDegrees(LAT);
        int N = int.Parse(Console.ReadLine());
        string[] closestDefib = "empty".Split();
        for (int i = 0; i < N; i++)
        {
            string defibInput = Console.ReadLine();
            defibInput += ";";
            string[] DEFIB = defibInput.Split(';');
            double LONb = convertDegrees(DEFIB[4]);
            double LATb = convertDegrees(DEFIB[5]);
            double x = (LONb - LONa) * Math.Cos((LATa + LATb) / 2);
            double y = (LATb - LATa);
            double d = ((Math.Sqrt((x * x) + (y * y))) * 6371);
            DEFIB[6] = d.ToString();
            if ((closestDefib[0] == "empty") || (double.Parse(closestDefib[6]) > double.Parse(DEFIB[6])))
            {
                closestDefib = DEFIB;
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(closestDefib[1]);
    }
    public static double convertDegrees(string input)
    {
        string[] num = input.Split(',');
        double degree;
        num[1] = num[1].Insert(0, "0.");
        degree = int.Parse(num[0]) + double.Parse(num[1]);
        return degree;
    }
}