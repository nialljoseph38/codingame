using System;
using System.Diagnostics;

internal class Defibrillators : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = true;
    Stopwatch stopWatch = new Stopwatch();
    public void Run(bool isTest, ref string result) {
        (int N, string LON, string LAT, string[] defibList) data = (3, "3,879483", "43,608177", new string[] {
            "1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217",
            "2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849",
            "3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854"
        });
        stopWatch.Start();
        string LON = isTest ? data.LON : Console.ReadLine();
        string LAT = isTest ? data.LAT : Console.ReadLine();
        double LONa = ConvertDegrees(LON);
        double LATa = ConvertDegrees(LAT);
        int N = isTest ? data.N : int.Parse(Console.ReadLine());
        string[] closestDefib = "empty".Split();
        for(int i = 0; i < N; i++) {
            string defibInput = isTest ? data.defibList[i] : Console.ReadLine();
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