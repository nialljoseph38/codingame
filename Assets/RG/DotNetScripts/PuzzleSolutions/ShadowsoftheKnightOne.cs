using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

internal class ShadowsoftheKnightOne : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = false;
    public void Run(bool isTest, ref string result, StreamReader streamReader) {
        //Stopwatch stopWatch = new Stopwatch();
        //stopWatch.Start();
        //string results = "";
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        int X = X0;
        int Y = Y0;
        int maxL = 0;
        int maxR = W - 1;
        int maxU = 0;
        int maxD = H - 1;

        // game loop
        while(true) {
            //int xDir = 0;
            //int yDir = 0;
            Console.Error.WriteLine(maxL);
            Console.Error.WriteLine(maxR);
            Console.Error.WriteLine(maxU);
            Console.Error.WriteLine(maxD);
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            if(bombDir.Contains("U")) {
                maxD = Y - 1;
            }
            if(bombDir.Contains("D")) {
                maxU = Y + 1;
            }
            if(bombDir.Contains("L")) {
                maxR = X - 1;
            }
            if(bombDir.Contains("R")) {
                maxL = X + 1;
            }
            X = (maxR + maxL) / 2;
            Y = (maxU + maxD) / 2;


            //stopWatch.Stop();
            //TimeElapsed = stopWatch.Elapsed;
            Console.WriteLine((X) + " " + (Y));
        }
    }
}