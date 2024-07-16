using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler {
    private static List<IPuzzle> puzzles = new();
    private SceneData sceneData;

    private PuzzleHandler() {
        Start();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init() {
        _ = new PuzzleHandler();
    }

    private void Start() {
        PuzzleDotNet.FindClassesImplementingInterface(ref puzzles);

        sceneData = Resources.Load<SceneData>("SceneData");
        if (sceneData == null) {
            Debug.LogError("SceneData not found");
            return;
        }
        
        var puzzleMenuView = new PuzzleMenuView(sceneData, puzzles);
    }
}