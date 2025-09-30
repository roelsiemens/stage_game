using UnityEngine;

public class TestPM : MonoBehaviour
{
    /// <summary>
    /// changes the color of the target to the color of the colourd object, if the color is not white
    /// </summary>
    /// <param name="colourdObject"></param>
    /// <param name="target"></param>
    public void ColorChange (GameObject colourdObject, GameObject target)
    {
        var targetSprite = target.GetComponentInChildren<SpriteRenderer>();
        var colorSprite = colourdObject.GetComponentInChildren<SpriteRenderer>();
        if(colorSprite.color != Color.white && colorSprite != null)
        {
            targetSprite.color = colorSprite.color;
        }
            
    }

    /// <summary>
    /// checks if the CL is connected with a color, if true it changes the color of the CL to the color of the connected PP
    /// </summary>
    /// <param name="CWC"></param>
    /// <param name="color"></param>
    public void CheckConnections(bool CWC, GameObject colourdObject, GameObject target)
    {
        if (CWC)
        {
            Debug.Log("CL is connected with color");
            ColorChange(colourdObject, target);
        }
        else
        {
            Debug.Log("CL is NOT connected with color");
        }
    }
}
