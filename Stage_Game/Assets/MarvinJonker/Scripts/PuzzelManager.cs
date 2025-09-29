using UnityEngine;
using UnityEngine.UI;

public class PuzzelManager : MonoBehaviour
{
    [Header("Kleur instellingen")]
    public Color progressColor = new Color(0.5f, 0.8f, 1f, 1f); // lichtblauw

    [System.Serializable]
    public class BeginOfPuzzle
    {
        public GameObject beginPiece;
    }
    public BeginOfPuzzle[] BeginOfPuzzles;

    [System.Serializable]
    public class PuzzleButton
    {
        public GameObject puzzleObject;
        public PuzzlePiece puzzlePiece;
    }
    public PuzzleButton[] puzzleButtons;

    [System.Serializable]
    public class ConnectingLine
    {
        public GameObject cl;
        public bool connected = false;
    }
    public ConnectingLine[] connectingLines;


    void Start()
    {
        // Geef alle BeginOfPuzzle een lichtblauwe kleur
        foreach (var bop in BeginOfPuzzles)
        {
            var matColor = bop.beginPiece.GetComponentInChildren<RawImage>();
            if (matColor != null)
                matColor.color = progressColor;
        }

        // Koppel rotatie-functies aan de puzzelbuttons
        foreach (var pb in puzzleButtons)
        {
            PuzzlePiece piece = pb.puzzlePiece; // closure fix
            //pb.button.onClick.AddListener(() => piece.RotatePiece());
        }
    }

    /// <summary>
    /// Geeft zowel de lijn als het doelwit dezelfde kleur
    /// </summary>
    public void Colorize(GameObject cline, GameObject target)
    {
        // lijn kleuren
        var lineSprite = cline.GetComponent<SpriteRenderer>();
        if (lineSprite != null)
            lineSprite.color = progressColor;

        // target kleuren
        var targetSprite = target.GetComponent<SpriteRenderer>();
        if (targetSprite != null)
            targetSprite.color = progressColor;
    }
}
