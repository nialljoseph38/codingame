using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

        foreach(var puzzle in puzzles) {
            if(puzzle.createButton) {
                var puzzleButton = GameObject.Instantiate(sceneData.puzzleButtonPrefab, puzzleMenuReference.buttonsParent);
                puzzleButton.textContainer.text = puzzle.GetType().Name;
                puzzleButton.button.onClick.AddListener(() => {
                    string scriptDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string relativePath = Path.Combine(scriptDirectory, @"..\..\Assets\RG\Data\Input.txt");
                    string fullPath = Path.GetFullPath(relativePath);
                    if(!File.Exists(fullPath)) {
                        using(FileStream fs = File.Create(fullPath));
                        return;
                    }
                    StreamReader streamReader = new StreamReader(fullPath);
                    while(true) {
                        string line = streamReader.ReadLine();
                        if (line == puzzle.GetType().Name || line == null) {
                            break;
                        }
                    }
                    string result = "";
                    puzzle.Run(true, ref result, streamReader);
                    //Debug.Log(puzzle.TimeElapsed.TotalMilliseconds);
                    puzzleMenuReference.resultContainer.text = result;
                    puzzleMenuReference.timeContainer.text = puzzle.TimeElapsed.TotalMilliseconds.ToString();
                });
            }
        }
    }

}