using System;
using System.Collections.Generic;
using System.Linq;

public class PuzzleDotNet {
    private static List<IPuzzle> puzzles = new();
    
    public static void Main(string[] args) {
        _ = new PuzzleDotNet();
    }
    
    private PuzzleDotNet() {
        FindClassesImplementingInterface(ref puzzles);
        foreach(var puzzle in puzzles) {
            if(puzzle is Defibrillators) {
                var _ = "";
                puzzle.Run(true, ref _);
            }
        }
    }

    public static void FindClassesImplementingInterface<T>(ref List<T> instances) {
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(T)));
        foreach(var type in types) {
            var aoc = (T)Activator.CreateInstance(type)!;

            instances.Add(aoc);
        }
    }
}