using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler {
    private static List<IPuzzle> puzzles = new();

    private PuzzleHandler() {
        Start();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init() {
        _ = new PuzzleHandler();
    }

    private void Start() {
        PuzzleDotNet.FindClassesImplementingInterface(ref puzzles);
        foreach(var puzzle in puzzles) {
            if(puzzle is Defibrillators) {
                string result = "";
                puzzle.Run(true, ref result);
                Debug.Log(result);
            }
        }
    }
}