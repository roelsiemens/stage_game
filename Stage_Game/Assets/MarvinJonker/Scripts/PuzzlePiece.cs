using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    // Draai het puzzelstuk 90 graden
    public void RotatePiece()
    {
        transform.Rotate(0, 0, 90f);
    }   
}
