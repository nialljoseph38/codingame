using System;
using System.Collections.Generic;

internal class HorseRacingDuals : IPuzzle {
    public void Run(bool isTest, ref string result) {
        int N = int.Parse(Console.ReadLine());
        List<int> list = new();
        int minDist = -1;
        for(int i = 0; i < N; i++) {
            list.Add(int.Parse(Console.ReadLine()));

        }
        list.Sort();
        for(int j = 0; j < N - 1; j++) {
            if((list[j + 1] - list[j] < minDist) | (minDist == -1)) {
                minDist = list[j + 1] - list[j];
            }
        }
        Console.WriteLine(minDist);
    }
}