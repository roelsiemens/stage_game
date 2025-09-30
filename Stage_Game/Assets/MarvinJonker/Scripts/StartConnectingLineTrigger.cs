using UnityEngine;

public class StartConnectingLineTrigger : MonoBehaviour
{
    public PuzzelManager manager; // verwijzing naar manager waar arrays in zitten
    public PuzzlePiece puzzlePiece; // verwijzing naar puzzlepiece script

    public bool connected = false;

    private void Start()
    {
        // automatische assignment voor puzzlemanager
        manager = GameObject.Find("Puzzle").GetComponent<PuzzelManager>();

        if (CompareTag("StartCL"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = manager.progressColor;
            connected = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("StartCL"))
        {
            // check puzzle pieces
            foreach (var pb in manager.puzzleButtons)
            {
                if (collision.gameObject == pb.puzzleObject)
                {
                    manager.colorChange(gameObject, pb.puzzleObject);
                    pb.connected = true;
                }
            }
            // check begin of puzzles
            foreach (var bop in manager.BeginOfPuzzles)
            {
                if (collision.gameObject == bop.beginPiece)
                {
                    manager.colorChange(gameObject, bop.beginPiece);
                }
            }
        }
        if (CompareTag("CL") && collision.CompareTag("Puzzlepiece") && puzzlePiece.connected)
        {
            // check puzzle pieces
            foreach (var pb in manager.puzzleButtons)
            {
                if (collision.gameObject == pb.puzzleObject)
                {
                    manager.colorChange(gameObject, pb.puzzleObject);
                    pb.connected = true;
                }
            }
            // check begin of puzzles
            foreach (var bop in manager.BeginOfPuzzles)
            {
                if (collision.gameObject == bop.beginPiece)
                {
                    manager.colorChange(gameObject, bop.beginPiece);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CompareTag("CL"))
        {
            // checkt loss of contact met puzzlepieces
            foreach (var pb in manager.puzzleButtons)
            {
                pb.connected = false;
                pb.puzzleObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}