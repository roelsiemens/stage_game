using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    public bool connected;

    public PuzzelManager manager; // verwijzing naar je manager waar arrays in zitten

    void Start()
    {
        // automatische assignment voor puzzlemanager
        manager = GameObject.Find("Puzzle").GetComponent<PuzzelManager>();
    }

    private void Update()
    {
        foreach (var pb in manager.puzzleButtons)
        {
            if (pb.connected == true)
            {
                connected = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var pb in manager.puzzleButtons)
        {
            if (collision.gameObject.GetComponentInChildren<SpriteRenderer>().color == manager.progressColor)
            {
                print("connected");
                pb.connected = true;
                manager.colorChange(pb.puzzleObject, gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var pb in manager.puzzleButtons)
        {
            if (collision.gameObject.GetComponentInChildren<SpriteRenderer>().color != manager.progressColor)
            {
                print("not connected");
                pb.connected = false;
                pb.puzzleObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
        }
    }
}