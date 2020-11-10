using UnityEngine;
using UnityEngine.Tilemaps;

public class IslandMaker : MonoBehaviour {

    [Header("Island Type")]
    public bool rectangleIsland;
    [Header("Island Settings")]
    public int mapWidth;
    public int mapHeight;
    [Range(0, 1)]
    public float islandHeight;
    [Header("Noise Settings")]
    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    [Space]
    public int seed;
    public Vector2 offset;
    [Space]
    public bool autoUpdate;
    [Header("References")]
    public Tilemap tilemap;
    public RuleTile tile;

    private float[,] falloffMap;

    public void GenerateRectangleIsland() {
        if (tilemap) {
            tilemap.ClearAllTiles();
            for (int y = 0; y < mapHeight; y++) {
                for (int x = 0; x < mapWidth; x++) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }

        CenterIsland();
    }

    public void GenerateIsland() {
        seed = Random.Range(-10000, 10000);
        GenerateIsland(seed);
    }

    public void GenerateIsland(int seed) {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        if (tilemap) {
            tilemap.ClearAllTiles();
            for (int y = 0; y < noiseMap.GetLength(1); y++) {
                for (int x = 0; x < noiseMap.GetLength(0); x++) {
                    noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);

                    if (noiseMap[x, y] > islandHeight) tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }

        CenterIsland();
    }

    private void CenterIsland() {
        tilemap.transform.position = this.transform.position - new Vector3(mapWidth / 2, (mapHeight / 2), 0);
    }

    void OnValidate() {
        if (mapWidth < 1) mapWidth = 1;
        if (mapHeight < 1) mapHeight = 1;
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;

        falloffMap = FalloffMaker.GenerateFalloffMap(mapWidth, mapHeight);
    }
}
