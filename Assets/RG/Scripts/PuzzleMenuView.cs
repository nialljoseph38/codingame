using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMenuView {
    private readonly SceneData sceneData;
    private readonly List<IPuzzle> puzzles;
    private PuzzleMenuReference puzzleMenuReference;
    
    public PuzzleMenuView(SceneData sceneData, List<IPuzzle> puzzles) {
        this.sceneData = sceneData;
        this.puzzles = puzzles;
        InstantiatePuzzleMenu();
    }
    private void InstantiatePuzzleMenu() {
        puzzleMenuReference = GameObject.Instantiate(sceneData.puzzleMenuPrefab);
        
        foreach (var puzzle in puzzles) {
            var puzzleButton = GameObject.Instantiate(sceneData.puzzleButtonPrefab, puzzleMenuReference.buttonsParent);
            puzzleButton.textContainer.text = puzzle.GetType().Name;
            puzzleButton.button.onClick.AddListener(() => {
                string result = "";
                puzzle.Run(true, ref result);
                Debug.Log(puzzle.TimeElapsed.TotalMilliseconds);
                puzzleMenuReference.resultContainer.text = result;
            });
        }
    }

}