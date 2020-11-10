using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IslandMaker))]
public class IslandMakerEditor : Editor {

    public override void OnInspectorGUI() {
        IslandMaker islandMaker = (IslandMaker)target;

        if (DrawDefaultInspector()) {
            if(islandMaker.autoUpdate) {
                Generate(islandMaker, islandMaker.rectangleIsland, false);
            }
        }

        if (GUILayout.Button("Generate Island")) {
            Generate(islandMaker, islandMaker.rectangleIsland, true);
        }
    }

    private void Generate(IslandMaker islandMaker, bool rectangleIsland, bool randomizeSeed) {
        if (rectangleIsland) {
            islandMaker.GenerateRectangleIsland();
        } else {
            if(randomizeSeed) {
                islandMaker.GenerateIsland();
            } else {
                islandMaker.GenerateIsland(islandMaker.seed);
            }
        }
    }
}
