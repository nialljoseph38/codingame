using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Project/SceneData")]
public class SceneData : ScriptableObject {
    public PuzzleMenuReference puzzleMenuPrefab;
    public PuzzleButton puzzleButtonPrefab;
    
}
