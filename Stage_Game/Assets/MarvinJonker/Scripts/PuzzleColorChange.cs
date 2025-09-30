using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIOverlapHighlight : MonoBehaviour
{

    // dit script is niet in gebruik

    public Color progressColor = Color.cyan;

    public void colorChange(GameObject bop, GameObject target)
    {
        var targetSprite = target.GetComponent<SpriteRenderer>();

        var bopSprite = bop.GetComponent<SpriteRenderer>();
        if (bopSprite != null )
            targetSprite.color = progressColor;

        if (CompareTag("PuzzlePiece") && target.CompareTag("PuzzlePiece"))
        {
            targetSprite.color = progressColor;
        }
    }


    
}
