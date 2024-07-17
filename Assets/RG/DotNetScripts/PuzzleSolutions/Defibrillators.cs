using System;
using System.Diagnostics;
using System.IO;
using static UnityEngine.UIElements.UxmlAttributeDescription;

internal class Defibrillators : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = true;
    
    
    public void Run(bool isTest, ref string result, StreamReader streamReader) {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        string LON = isTest ? streamReader.ReadLine() : Console.ReadLine();
        string LAT = isTest ? streamReader.ReadLine() : Console.ReadLine();
        double LONa = ConvertDegrees(LON);
        double LATa = ConvertDegrees(LAT);
        int N = isTest ? int.Parse(streamReader.ReadLine()) : int.Parse(Console.ReadLine());
        string[] closestDefib = "empty".Split();
        for(int i = 0; i < N; i++) {
            string defibInput = isTest ? streamReader.ReadLine() : Console.ReadLine();
            defibInput += ";";
            string[] DEFIB = defibInput.Split(';');
            double LONb = ConvertDegrees(DEFIB[4]);
            double LATb = ConvertDegrees(DEFIB[5]);
            double x = (LONb - LONa) * Math.Cos((LATa + LATb) / 2);
            double y = LATb - LATa;
            double d = Math.Sqrt((x * x) + (y * y)) * 6371;
            DEFIB[6] = d.ToString();
            if(closestDefib[0] == "empty" || double.Parse(closestDefib[6]) > double.Parse(DEFIB[6])) {
                closestDefib = DEFIB;
            }
        }
        result = closestDefib[1];
        stopWatch.Stop();
        TimeElapsed = stopWatch.Elapsed;
        Console.WriteLine(closestDefib[1]);
    }
    private static double ConvertDegrees(string input) {
        string[] num = input.Split(',');
        double degree;
        num[1] = num[1].Insert(0, "0.");
        degree = int.Parse(num[0]) + double.Parse(num[1]);
        return degree;
    }
}