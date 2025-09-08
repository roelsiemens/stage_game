using UnityEngine;
using Random = UnityEngine.Random;

public class LightsOutManager : MonoBehaviour
{
    [Header("Grid")]
    public int width = 5;
    public int height = 5;
    public float spacing = 1.05f;       // distance between tile centers
    public GameObject tilePrefab;
    public Transform boardParent;        // optional; created at runtime if null

    [Header("Start State")]
    public int scramblePresses = 12;     // random presses applied at Start

    [Header("Read-only")]
    public int moveCount;

    private LightTile[,] _tiles;

    private void Start()
    {
        if (boardParent == null)
        {
            var parentGO = new GameObject("Board");
            boardParent = parentGO.transform;
            boardParent.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        GenerateGrid();
        Scramble(scramblePresses);
    }

    private void Update()
    {
        // R to reshuffle, C to clear, 1..9 to set grid sizes quickly (optional)
        if (Input.GetKeyDown(KeyCode.R)) Scramble(scramblePresses);
        if (Input.GetKeyDown(KeyCode.C)) ClearAll(off: true);
    }

    private void GenerateGrid()
    {
        // Clean up previous, if any
        if (_tiles != null)
        {
            foreach (var t in _tiles)
                if (t != null) Destroy(t.gameObject);
        }

        _tiles = new LightTile[width, height];

        // Center the grid around origin
        Vector3 originOffset = new Vector3(
            -(width - 1) * spacing * 0.5f,
            0f,
            -(height - 1) * spacing * 0.5f
        );

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * spacing, 0f, y * spacing) + originOffset;
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity, boardParent);
                obj.name = $"Tile_{x}_{y}";

                var tile = obj.GetComponent<LightTile>();
                tile.Init(x, y, this, startOn: false);
                _tiles[x, y] = tile;
            }
        }

        moveCount = 0;
    }

    public void PressAt(int x, int y, bool checkWin, bool countMove)
    {
        ToggleAt(x, y);
        ToggleAt(x + 1, y);
        ToggleAt(x - 1, y);
        ToggleAt(x, y + 1);
        ToggleAt(x, y - 1);

        if (countMove) moveCount++;

        if (checkWin && IsSolved())
        {
            Debug.Log($"Solved! Moves: {moveCount}");
            // Hook up a UI popup or sound here if you like.
        }
    }

    private void ToggleAt(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height) return;
        _tiles[x, y].Toggle();
    }

    private bool IsSolved()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                if (!_tiles[x, y].IsOn) return false; // fail if ANY tile is off
        return true; // all tiles are ON
    }


    public void Scramble(int presses)
    {
        // Start from solved (all off) then apply random valid "press" moves.
        ClearAll(off: true);
        for (int i = 0; i < presses; i++)
        {
            int rx = Random.Range(0, width);
            int ry = Random.Range(0, height);
            PressAt(rx, ry, checkWin: false, countMove: false);
        }
        moveCount = 0;
    }

    private void ClearAll(bool off)
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                _tiles[x, y].SetState(on: !off);
    }
}
