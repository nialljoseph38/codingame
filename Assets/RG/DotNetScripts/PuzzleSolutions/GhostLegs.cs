using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

internal class GhostLegs : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = true;
    Stopwatch stopWatch = new Stopwatch();
    public void Run(bool isTest, ref string result) {
        (int W, int H, string[] lines) data = (7, 7, new string[] {
            "A  B  C",
            "|  |  |",
            "|--|  |",
            "|  |--|",
            "|  |--|",
            "|  |  |",
            "1  2  3"
        });
        stopWatch.Start();
        string[] inputs = isTest ? data.lines : Console.ReadLine().Split(' ');
        int W = isTest ? data.W : int.Parse(inputs[0]);
        int H = isTest ? data.H : int.Parse(inputs[1]);
        string results = "";
        List<string> diagram = new();
        for(int j = 0; j < H; j++) {
            diagram.Add( isTest ? inputs[j] : Console.ReadLine());
        }
        for(int i = 0; i < W; i += 3) {
            string firstline = diagram[0];
            char T = firstline[i];
            char B = ' ';
            int currentRow = i;
            for(int j = 0; j < H - 1; j++) {
                string line = diagram[j + 1];
                if(currentRow < W - 1 && line[currentRow + 1] == '-') {
                    currentRow += 3;
                }
                else if(currentRow != 0 && line[currentRow - 1] == '-') {
                    currentRow -= 3;
                }
                if(line[0] != '|') {
                    B = line[currentRow];
                }
            }
            if(isTest) { results += (T + B.ToString() + "\n"); }
            else {Console.WriteLine(T + B.ToString()); }
        }
        result = results;
        stopWatch.Stop();
        TimeElapsed = stopWatch.Elapsed;
    }
}