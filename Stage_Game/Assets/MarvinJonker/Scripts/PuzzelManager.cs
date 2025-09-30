using UnityEngine;
using UnityEngine.UI;

public class PuzzelManager : MonoBehaviour
{
    [Header("Kleur instellingen")]
    public Color progressColor = Color.cyan;

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
        public bool connected = false;
    }
    public PuzzleButton[] puzzleButtons;

    [System.Serializable]
    public class ConnectingLine
    {
        public GameObject cl;
    }
    public ConnectingLine[] connectingLines;

    /// <summary>
    /// Geeft de kleur van het object aan het doelwit
    /// </summary>
    public void colorChange(GameObject bop, GameObject target)
    {
        var targetSprite = target.GetComponentInChildren<SpriteRenderer>();

        var bopSprite = bop.GetComponent<SpriteRenderer>();
        if (bopSprite != null)
            targetSprite.color = progressColor;
    }
}
