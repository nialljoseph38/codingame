using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

internal class HorseRacingDuals : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = true;
    Stopwatch stopWatch = new Stopwatch();
    public void Run(bool isTest, ref string result) {
        (int N, int[] horses) data = (3, new int[] {5, 8, 9});
        stopWatch.Start();
        int N = isTest ? data.N : int.Parse(Console.ReadLine());
        List<int> list = new();
        int minDist = -1;
        for(int i = 0; i < N; i++) {
            list.Add(isTest ? data.horses[i] : int.Parse(Console.ReadLine()));

        }
        list.Sort();
        for(int j = 0; j < N - 1; j++) {
            if((list[j + 1] - list[j] < minDist) | (minDist == -1)) {
                minDist = list[j + 1] - list[j];
            }
        }
        stopWatch.Stop();
        TimeElapsed = stopWatch.Elapsed;
        result = minDist.ToString();
        Console.WriteLine(minDist);
    }
}