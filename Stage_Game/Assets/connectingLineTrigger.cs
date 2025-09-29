using UnityEngine;

public class ConnectingLineTrigger : MonoBehaviour
{
    public Color progressColor = new Color(0.5f, 0.8f, 1f, 1f);
    public PuzzelManager manager; // verwijzing naar je manager waar arrays in zitten


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check puzzle pieces
        foreach (var pb in manager.puzzleButtons)
        {
            if (collision.gameObject == pb.puzzleObject)
                manager.Colorize(gameObject, pb.puzzleObject);
        }

        // check begin of puzzles
        foreach (var bop in manager.BeginOfPuzzles)
        {
            if (collision.gameObject == bop.beginPiece)
                manager.Colorize(gameObject, bop.beginPiece);
        }
    }
}
