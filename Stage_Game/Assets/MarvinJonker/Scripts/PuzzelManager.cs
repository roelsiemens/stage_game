using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuzzelManager : MonoBehaviour
{
    [System.Serializable]
    public class PuzzleButton
    {
        public Button button;          // De UI Button
        public PuzzlePiece puzzlePiece; // Het puzzelstuk dat erbij hoort
    }

    public PuzzleButton[] puzzleButtons; // Sleep alles in via Inspector

    void Start()
    {
        foreach (var pb in puzzleButtons)
        {
            // Maak een lokale kopie zodat de closure werkt
            PuzzlePiece piece = pb.puzzlePiece;
            pb.button.onClick.AddListener(() => piece.RotatePiece());
        }
    }

}
