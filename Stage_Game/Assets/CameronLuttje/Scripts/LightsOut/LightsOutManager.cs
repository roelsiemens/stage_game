using UnityEngine;
using TMPro;

public class LightsOutManager : MonoBehaviour
{
    [Header("Board Settings")]
    public int width = 5;
    public int height = 5;
    public float spacing = 1.05f;
    public GameObject tilePrefab;
    public Transform boardParent;

    [Header("Game Settings")]
    public int scramblePresses = 12;

    [Header("UI References")]
    public TMP_Text timerText;
    public TMP_Text movesText;
    public TMP_Text winText;

    private LightTile[,] tiles;
    private int moveCount;
    private float elapsedTime;
    private bool timerRunning;
    private bool gameOver;
    public bool GameOver { get { return gameOver; } }

    private void Start()
    {
        if (boardParent == null)
        {
            boardParent = new GameObject("Board").transform;
        }

        GenerateGrid();
        Scramble(scramblePresses);

        if (winText != null) winText.gameObject.SetActive(false);
        UpdateMovesUI();
        UpdateTimerUI();
    }

    private void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scramble(scramblePresses);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearBoard();
        }
    }

    private void GenerateGrid()
    {
        tiles = new LightTile[width, height];

        Vector3 offset = new Vector3(
            -(width - 1) * spacing * 0.5f,
            0f,
            -(height - 1) * spacing * 0.5f
        );

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * spacing, 0f, y * spacing) + offset;
                GameObject obj = Instantiate(tilePrefab, pos, Quaternion.identity, boardParent);
                obj.name = "Tile_" + x + "_" + y;

                LightTile tile = obj.GetComponent<LightTile>();
                tile.Init(x, y, this, true); // start ON
                tiles[x, y] = tile;
            }
        }
    }

    public void PressAt(int x, int y, bool checkWin, bool countMove)
    {
        if (gameOver) return;

        ToggleAt(x, y);
        ToggleAt(x + 1, y);
        ToggleAt(x - 1, y);
        ToggleAt(x, y + 1);
        ToggleAt(x, y - 1);

        if (countMove)
        {
            moveCount++;
            UpdateMovesUI();
        }

        if (!timerRunning && moveCount > 0)
        {
            StartTimer();
        }

        if (checkWin && IsSolved())
        {
            WinGame();
        }
    }

    private void ToggleAt(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            tiles[x, y].Toggle();
        }
    }

    private bool IsSolved()
    {
        foreach (LightTile tile in tiles)
        {
            if (!tile.IsOn) return false;
        }
        return true;
    }

    public void Scramble(int presses)
    {
        SetAll(true);

        for (int i = 0; i < presses; i++)
        {
            int rx = Random.Range(0, width);
            int ry = Random.Range(0, height);
            PressAt(rx, ry, false, false);
        }

        moveCount = 0;
        gameOver = false;
        ResetTimer();

        if (winText != null) winText.gameObject.SetActive(false);
        UpdateMovesUI();
        UpdateTimerUI();
    }

    private void ClearBoard()
    {
        SetAll(false);
        moveCount = 0;
        gameOver = false;
        ResetTimer();

        if (winText != null) winText.gameObject.SetActive(false);
        UpdateMovesUI();
        UpdateTimerUI();
    }

    private void SetAll(bool on)
    {
        foreach (LightTile tile in tiles)
        {
            tile.SetState(on);
        }
    }

    private void WinGame()
    {
        gameOver = true;
        timerRunning = false;

        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "Solved!\nTime: " + FormatTime(elapsedTime) + "\nMoves: " + moveCount;
        }

        Debug.Log("You solved it!");
    }

    private void StartTimer()
    {
        elapsedTime = 0f;
        timerRunning = true;
    }

    private void ResetTimer()
    {
        elapsedTime = 0f;
        timerRunning = false;
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + FormatTime(elapsedTime);
        }
    }

    private void UpdateMovesUI()
    {
        if (movesText != null)
        {
            movesText.text = "Moves: " + moveCount;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        int hundredths = (int)(time * 100f) % 100;

        return minutes.ToString("00") + ":" +
               seconds.ToString("00") + "." +
               hundredths.ToString("00");
    }
}
