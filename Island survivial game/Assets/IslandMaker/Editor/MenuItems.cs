using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuItems {

    [MenuItem("GameObject/Island Maker/New Island", false, 10)]
    private static void CreateNewIsland() {
        GameObject island = new GameObject("Island", typeof(IslandMaker), typeof(Grid));
        GameObject tilemap = new GameObject("Tilemap", typeof(Tilemap), typeof(TilemapRenderer));
            tilemap.transform.SetParent(island.transform);
    }
}
